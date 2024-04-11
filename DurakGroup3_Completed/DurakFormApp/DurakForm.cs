using System;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;
using DurakLibrary;
using System.IO;

namespace DurakFormApp
{
    public partial class DurakForm : Form
    {

        private string gameRules = @"1. A deck comprising 36 cards with the following denominations: 6, 7, 8, 9, 10, J, Q, K, A. (The deck is randomized prior to gameplay.)
2. Each player receives a hand consisting of six cards.
3. One card is drawn from the bottom of the deck, revealed to all players, and designated as the trump suit for the current match. This card is then removed from play.
4. The player holding the lowest-valued card in their hand becomes the first attacker.
5. The attacking player initiates the round by playing a card from their hand.
6. The defending player may opt to counter the attack by playing a card that meets one of the following criteria:
   a. Same suit but higher value.
   b. A card from the trump suit, regardless of value.
   c. A card of the same rank to exchange roles of attacker and defender, marking the completion of a round. This option may be exercised up to three times.
7. Upon successfully defending against an attack, the attacker may launch subsequent attacks using cards of values present on the field, up to a maximum of six attacks per round.
8. If the defending player is unable or unwilling to defend against the attack, they must pick up all cards involved in the attack.
9. Both players replenish their hands to a minimum of six cards from the deck, with the attacker drawing first in case of insufficient cards.
10. Upon successful defense or exhaustion of possible attacks, all cards involved in the attack are discarded, and a new round commences.
11. The attacker retains their role if successful; otherwise, the defender becomes the new attacker for the subsequent round.
12. Rounds persist until the deck is depleted.
13. After the deck is emptied, gameplay continues without card draws.
14. Players exit the game upon depletion of their cards or the exhaustion of the deck. The player with cards remaining at the end loses.
15. Each player maintains their individual log file and can reset statistics via the provided radio button.";

        private List<CardBox.CardBox> fieldCards = new List<CardBox.CardBox>();
        private GameDeck gameDeck = new GameDeck();
        private int indexOfPlayerCard = 0;
        private bool aiHandVisible = false;
        private int offsetPlayer = 215;
        private int offsetAI = 215;
        private AI aiPlayer = new AI("AI");
        private Player humanPlayer;
        private Player attackingPlayer;
        private Player defendingPlayer;
        private Player currPlayer;
        private List<CardBox.CardBox> playerCards = new List<CardBox.CardBox>();
        private List<CardBox.CardBox> aiCards = new List<CardBox.CardBox>();
        private bool gameEnder = false;
        private bool flag = false;
        private int countTurns = 0;
        private GameField gamePlayingField = new GameField();
        private GameCard cardTrump;
        private const string INITIALATTACK = "INITIALATTACK";
        private const string PLAYATTACKER = "PLAYATTACKER";
        private const string PLAYDEFENDER = "PLAYDEFENDER";
        private string currRound = INITIALATTACK;

        private int numGamesPlayed = 0;
        private int wonGames = 0;
        private int lostGames = 0;

        private int indexOfAICard = 0;
        private bool flagMatcher = false;
        private int fieldOffset = 0;
        private DateTime currDate = DateTime.Now;
        private const int ATTACKMAX = 6;
        private bool gameEnd = false;
        private bool skipped = true;



        public DurakForm()
        {
            InitializeComponent();
            btnSkipTurn.Enabled = false;

            gameLogWriter("Application has started" + "\n" + "Game Started At: " + currDate.ToString("F"));
        }

        private void ControlCreator()
        {

            for (int i = 0; i < humanPlayer.playerHand.gethandSize(); i++)
            {
                CardBox.CardBox newCardBox = new CardBox.CardBox(humanPlayer.playerHand.GetCard(i));
                newCardBox.Click += CardBox_Click;// Wire CardBox_Click
                playerCards.Add(newCardBox);
            }
            for (int i = 0; i < aiPlayer.playerHand.gethandSize(); i++)
            {
                CardBox.CardBox newCardBox = new CardBox.CardBox(aiPlayer.playerHand.GetCard(i));
                aiCards.Add(newCardBox);
            }
            lblDeckSizeValue.Text = gameDeck.getCardsRemaining().ToString();

        }

        private void ControlDisplayer()
        {
            offsetPlayer = offsetPlayer - (humanPlayer.playerHand.gethandSize() - 6) * 20 / 100;
            offsetAI = offsetAI - (aiPlayer.playerHand.gethandSize() - 6) * 20 / 100;

            for (int i = humanPlayer.playerHand.gethandSize() - 1; i >= 0; i--)
            {
                playerCards[i].Left = (i * 20) + offsetPlayer;
                this.pnPlayerHand.Controls.Add(playerCards[i]);
            }
            if (aiCards.Count > 0)
            {
                for (int i = aiPlayer.playerHand.gethandSize() - 1; i >= 0; i--)
                {
                    aiCards[i].Left = (i * 20) + offsetAI;
                    aiCards[i].FaceUp = aiHandVisible;
                    this.pnAIHand.Controls.Add(aiCards[i]);
                }
            }

        }

        void CardBox_Click(object sender, EventArgs e)
        {
            CardBox.CardBox aCardBox = sender as CardBox.CardBox;

            if (aCardBox != null)
            {

                for (int i = 0; i < humanPlayer.playerHand.gethandSize(); i++)
                {
                    if (aCardBox.Card == humanPlayer.playerHand.GetCard(i))
                    {
                        indexOfPlayerCard = i;
                    }
                }
                lblCardSelected.Text = aCardBox.Card.ToString();


            }

        }

        private void chkAIHandToggle_CheckedChanged(object sender, EventArgs e)
        {
            aiHandVisible = !aiHandVisible;
            ControlDisplayer();
        }

        private void lblPlayerTurn_TextChanged(object sender, EventArgs e)
        {

        }

        public void gameLogWriter(string msg)
        {
            string filePath = "../../logs/GameLogs/" + currDate.ToString("yyyy-M-dd--HH-mm-ss") + "-GameLog.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {

                writer.WriteLine(msg);
            }
        }

        public void statLogWriter(string msg)
        {

            string path = "../../logs/PlayerStats/" + humanPlayer.playerName + "-StatsLog.txt";


            File.WriteAllText(path, "");

            using (StreamWriter writer = new StreamWriter(path, true))
            {

                writer.WriteLine(msg);

            }


        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            gameDeck = new GameDeck();
            countTurns = 0;
            gameEnder = false;
            playerCards = new List<CardBox.CardBox>();
            aiCards = new List<CardBox.CardBox>();
            fieldCards = new List<CardBox.CardBox>();
            currRound = INITIALATTACK;
            flagMatcher = false;
            pnPlayerHand.Controls.Clear();
            pnAIHand.Controls.Clear();
            playerCards.Clear();
            gamePlayingField = new GameField();
            pnPlayingField.Controls.Clear();
     
        
            chkAIHandToggle.Enabled = true;
            gameEnd = false;
            offsetPlayer = 215;
            offsetAI = 215;
            numGamesPlayed = 0;
            wonGames = 0;
            lostGames = 0;
            btnResetStats.Visible = false;
            gameDeck.Shuffle();

            if(String.IsNullOrEmpty(txtNameInput.Text))
            {
               humanPlayer = new Player("Player1");
            }
            else
            {
                humanPlayer = new Player(txtNameInput.Text.Trim());
                humanPlayer.playerName= humanPlayer.playerName.Replace(" ", "");
            }

            statLogReader();
            numGamesPlayed += 1;
            humanPlayer.playerHand = new GameHand(gameDeck);
            aiPlayer.playerHand = new GameHand(gameDeck);

            cardTrump = gameDeck.getTrumpcard();

            lblTrumpCard.Text = "Trump Card: " + cardTrump.ToString();
            pnTrump.Controls.Clear();
            pnTrump.Controls.Add(new CardBox.CardBox(cardTrump));

            lblDeckSizeValue.Text = gameDeck.getCardsRemaining().ToString();

            lblCardSelected.Text = humanPlayer.playerHand.GetCard(indexOfPlayerCard).ToString();

            gameLogWriter("Trump Card: " + cardTrump.ToString() + "\n" + humanPlayer.playerName + "'s hand:" + humanPlayer.playerHand.ToString()
                + "\n" + aiPlayer.playerName + "'s hand:" + aiPlayer.playerHand.ToString());


            ControlCreator();
            ControlDisplayer();

            // Finding the attacker using the trump card.
            GameCard minOfPlayer = humanPlayer.playerHand.getMinOfSuite(cardTrump);
            GameCard minOfAI = aiPlayer.playerHand.getMinOfSuite(cardTrump);

            if (minOfPlayer == null)
            {
                attackingPlayer = aiPlayer;
            }
            else if (minOfAI == null)
            {
                attackingPlayer = humanPlayer;
            }
            else if ((int) minOfPlayer.rank < (int) minOfAI.rank)
            {
                attackingPlayer = humanPlayer;
            }
            else
            {
                attackingPlayer = aiPlayer;
            }

            if (attackingPlayer == humanPlayer)
            {
                lblPlayerTurn.Text = humanPlayer.playerName + " is the initial attacker.";
                gameLogWriter(humanPlayer.playerName + " is the initial attacker.");
                defendingPlayer = aiPlayer;
                currRound = PLAYDEFENDER;
            }
            else
            {

                if (fieldCards.Count > 0)
                {
                    if (aiPlayer == defendingPlayer)
                    {
                        currRound = PLAYDEFENDER;
                    }
                    else
                    {
                        currRound = PLAYATTACKER;
                    }
                }
                indexOfAICard = aiPlayer.AITurnCycle(cardTrump, gamePlayingField, currRound, flag);
                playAITurn();
                lblCardSelected.Text = humanPlayer.playerName + "is the defender;";
                currRound = PLAYATTACKER;

                defendingPlayer = humanPlayer;
                gameLogWriter(aiPlayer.playerName + " is the initial attacker.");
          
               
            }

            btnPlayCard.Enabled = true;
            btnDiscardPile.Enabled = true;
            btnStart.Visible = false;
            txtNameInput.Visible = false;
            btnSkipTurn.Enabled = true;
            statLogWriter(humanPlayer.playerName + "\n" + "Games Played: " + numGamesPlayed + "\n" + "Games Won: " + wonGames + "\n" + "Games Lost: " + lostGames);



        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(gameRules);
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDurak_Load(object sender, EventArgs e)
        {
            lblDeckSizeValue.Text = gameDeck.getCardsRemaining().ToString();
            GameCard theCard = new GameCard(GameSuit.Clubs, GameRank.Six, 1);
            theCard.FaceUp = false;
            GameCard theCard2 = new GameCard(GameSuit.Clubs, GameRank.Seven, 2);

            btnPlayCard.Enabled = false;
            btnDiscardPile.Enabled = false;
            btnStart.Visible = true;
            txtNameInput.Visible = true;
            chkAIHandToggle.Enabled = false;

        }

        private void FieldDisplayer()
        {
            fieldOffset = fieldOffset - (fieldCards.Count - 6) * 20 / 100;

            for (int i = fieldCards.Count - 1; i >= 0; i--)
            {
                fieldCards[i].Left = (i * 20) + fieldOffset;
                this.pnPlayingField.Controls.Add(fieldCards[i]);
            }
        }

        private void btnPlayCard_Click(object sender, EventArgs e)
        {
            GameCard aCard = humanPlayer.playerHand.GetCard(indexOfPlayerCard);


            if (aCard.suit == cardTrump.suit || fieldCards.Count == 0 || ((int)aCard.rank > (int)gamePlayingField.getCurrentCard().rank && aCard.suit == gamePlayingField.getCurrentCard().suit))
            {
                aCard = humanPlayer.playerHand.playCard(indexOfPlayerCard);
                CardBox.CardBox newCardBox = new CardBox.CardBox(aCard);
                gamePlayingField.cardPlayed(aCard);
                fieldCards.Add(newCardBox);

                lblCardSelected.Text = aCard.ToString();

                playerCards.Clear();
                FieldDisplayer();
                ControlCreator();
                this.pnPlayerHand.Controls.Clear();
                ControlDisplayer();

                // Changing the player
                currPlayer = aiPlayer;

                if (fieldCards.Count > 0)
                {
                    if (aiPlayer == defendingPlayer)
                    {
                        currRound = PLAYDEFENDER;
                    }
                    else
                    {
                        currRound = PLAYATTACKER;
                    }
                }
                indexOfAICard = aiPlayer.AITurnCycle(cardTrump, gamePlayingField, currRound, flag);
                playAITurn();
            }

        }

        private void playAITurn()
        {
            if (indexOfAICard == -1)
            {
                btnSkipTurn_Click(null, null);
            }

            GameCard aCard = aiPlayer.playerHand.GetCard(indexOfAICard);
            if (aCard.suit == cardTrump.suit && fieldCards.Count != 0 && gamePlayingField.getCurrentCard().suit == cardTrump.suit && (int)aCard.rank < (int)gamePlayingField.getCurrentCard().rank)
            {
                btnSkipTurn_Click(null, null);
            }
            else if (aCard.suit == cardTrump.suit || fieldCards.Count == 0 || ((int)aCard.rank > (int)gamePlayingField.getCurrentCard().rank && aCard.suit == gamePlayingField.getCurrentCard().suit))
            {

                aCard = aiPlayer.playerHand.playCard(indexOfAICard);

                aCard.FaceUp = true;
                gamePlayingField.cardPlayed(aCard);

                CardBox.CardBox newCardBox = new CardBox.CardBox(aCard);
                fieldCards.Add(newCardBox);

                aiCards.Clear();
                FieldDisplayer();
                ControlCreator();
                this.pnAIHand.Controls.Clear();
                ControlDisplayer();

                // Changing the player
                currPlayer = humanPlayer;
            }
            else
            {
                btnSkipTurn_Click(null, null);
            }
        }

        private void WinningAttack()
        {
            ArrayList cardsToBePickedUp = gamePlayingField.pickupField();

            fieldCards.Clear();
            this.pnPlayingField.Controls.Clear();

            FieldDisplayer();

            if (attackingPlayer == humanPlayer)
            {
                humanPlayer.DrawCards(gameDeck);

                this.pnPlayerHand.Controls.Clear();

                playerCards.Clear();

                for (int i = 0; i < humanPlayer.playerHand.gethandSize(); i++)
                {
                    CardBox.CardBox newCardBox = new CardBox.CardBox(humanPlayer.playerHand.GetCard(i));
                    newCardBox.Click += CardBox_Click;
                    playerCards.Add(newCardBox);
                }

                ControlDisplayer();
            }
            else
            {
                aiPlayer.DrawCards(gameDeck);
                this.pnAIHand.Controls.Clear();

                aiCards.Clear();

                for (int i = 0; i < aiPlayer.playerHand.gethandSize(); i++)
                {
                    CardBox.CardBox newCardBox = new CardBox.CardBox(aiPlayer.playerHand.GetCard(i));
                    aiCards.Add(newCardBox);
                }

                ControlDisplayer();
            }

            if (gameDeck.getCardsRemaining() == 0)
            {
                gameEnder = true;
            }

            if (gameEnder)
            {
                isGameOver();
            }


            if (defendingPlayer == humanPlayer)
            {
                string tempString = "";
                for (int i = 0; i < cardsToBePickedUp.Count; i++)
                {
                    humanPlayer.playerHand.addCard((GameCard)cardsToBePickedUp[i]);
                    tempString += " " + cardsToBePickedUp[i].ToString();

                }
                gameLogWriter(humanPlayer.playerName + " picked up:" + tempString);
                humanPlayer.DrawCards(gameDeck);

                this.pnPlayerHand.Controls.Clear();

                playerCards.Clear();

                for (int i = 0; i < humanPlayer.playerHand.gethandSize(); i++)
                {
                    CardBox.CardBox newCardBox = new CardBox.CardBox(humanPlayer.playerHand.GetCard(i));
                    newCardBox.Click += CardBox_Click;
                    playerCards.Add(newCardBox);
                }

                ControlDisplayer();
            }
            else
            {
                string tempString = "";
                for (int i = 0; i < cardsToBePickedUp.Count; i++)
                {
                    aiPlayer.playerHand.addCard((GameCard)cardsToBePickedUp[i]);
                    tempString += " " + cardsToBePickedUp[i].ToString();

                }
                gameLogWriter(aiPlayer.playerName + " picked up:" + tempString);
                
                aiPlayer.DrawCards(gameDeck);

                this.pnAIHand.Controls.Clear();

                aiCards.Clear();

                for (int i = 0; i < aiPlayer.playerHand.gethandSize(); i++)
                {
                    CardBox.CardBox newCardBox = new CardBox.CardBox(aiPlayer.playerHand.GetCard(i));
                    aiCards.Add(newCardBox);
                }

                ControlDisplayer();
            }

            if (gameDeck.getCardsRemaining() == 0)
            {
                gameEnder = true;
            }

            if (gameEnder)
            {
                isGameOver();
            }

            if (attackingPlayer == humanPlayer)
            {
                defendingPlayer = aiPlayer;
                attackingPlayer = humanPlayer;
            }
            else if (attackingPlayer == aiPlayer)
            {
                defendingPlayer = humanPlayer;
                attackingPlayer = aiPlayer;
            }

            countTurns = 0;
            currPlayer = attackingPlayer;
            currRound = INITIALATTACK;
            flag = false;

            lblPlayerTurn.Text = currPlayer.playerName + " is still attacker.";
            gameLogWriter("Round End");
            gameLogWriter(currPlayer.playerName + " is still attacker.");

            btnSkipTurn.Enabled = true;
            indexOfPlayerCard = 0;
            lblCardSelected.Text = humanPlayer.playerHand.GetCard(indexOfPlayerCard).ToString();

            lblDeckSizeValue.Text = gameDeck.getCardsRemaining().ToString();


        }

        private void btnSkipTurn_Click(object sender, EventArgs e)
        {

            if (currPlayer == defendingPlayer)
            {
                gameLogWriter(defendingPlayer.playerName + " skipped.");
                gameLogWriter("Round End");
                WinningAttack();


            }
            else if (currPlayer == attackingPlayer)
            {
                gameLogWriter(attackingPlayer.playerName + " skipped.");
                gameLogWriter("Round End");
                WinningDefend();
            }
            lblErrorMsg.Text = "";
            indexOfAICard = aiPlayer.AITurnCycle(cardTrump, gamePlayingField, currRound, flag);

            if (currPlayer == aiPlayer)
            {
                if (fieldCards.Count > 0)
                {
                    if (aiPlayer == defendingPlayer)
                    {
                        currRound = PLAYDEFENDER;
                    }
                    else
                    {
                        currRound = PLAYATTACKER;
                    }
                }
                indexOfAICard = aiPlayer.AITurnCycle(cardTrump, gamePlayingField, currRound, flag);
                playAITurn();
            }
         

            skipped = true;
        }

        public void isGameOver()
        {
            if (aiPlayer.playerHand.gethandSize() == 0)
            {
                gameLogWriter(aiPlayer.playerName + " won the game!!");
                MessageBox.Show("GAME OVER.");
                btnPlayCard.Enabled = false;
                btnDiscardPile.Enabled = false;
                btnSkipTurn.Enabled = false;
                btnStart.Visible = true;
                txtNameInput.Visible = true;
                txtNameInput.Text = humanPlayer.playerName;

                gameDeck = new GameDeck();
                countTurns = 0;
                gameEnder = false;
                playerCards = new List<CardBox.CardBox>();
                aiCards = new List<CardBox.CardBox>();
                fieldCards = new List<CardBox.CardBox>();
                currRound = INITIALATTACK;
                flagMatcher = false;
                pnPlayerHand.Controls.Clear();
                pnAIHand.Controls.Clear();
                playerCards.Clear();
                gamePlayingField = new GameField();
                pnPlayingField.Controls.Clear();
                cbTrumpCard.Visible = true;
                cardBox1.Visible = true;
                chkAIHandToggle.Enabled = true;
                btnResetStats.Visible = true;
                gameEnd = true;
                lostGames+=1;
                statLogWriter(humanPlayer.playerName + "\n" + "Games Played: " + numGamesPlayed + "\n" + "Games Won: " + wonGames + "\n" + "Games Lost: " + lostGames);
            }
            else if (humanPlayer.playerHand.gethandSize() == 0)
            {
                MessageBox.Show(humanPlayer.playerName + " Wins!");
                gameLogWriter(humanPlayer.playerName + " won the game!!");
                btnPlayCard.Enabled = false;
                btnDiscardPile.Enabled = false;
                btnSkipTurn.Enabled = false;
                btnStart.Visible = true;
                txtNameInput.Visible = true;
                txtNameInput.Text = humanPlayer.playerName;
                pnPlayerHand.Controls.Clear();
                pnAIHand.Controls.Clear();
                pnPlayingField.Controls.Clear();

                gameEnd = true;
                btnResetStats.Visible = true;
                gameDeck = new GameDeck();
                humanPlayer.DrawCards(gameDeck);
                wonGames+=1;
                statLogWriter(humanPlayer.playerName + "\n" + "Games Played: " + numGamesPlayed + "\n" + "Games Won: " + wonGames + "\n" + "Games Lost: " + lostGames);

            }
            //cardBox1.Visible = false;

        }

        private void WinningDefend()
        {
            gamePlayingField.discardField();

            fieldCards.Clear();
            this.pnPlayingField.Controls.Clear();

            FieldDisplayer();

            if (attackingPlayer == humanPlayer)
            {
                humanPlayer.DrawCards(gameDeck);

                this.pnPlayerHand.Controls.Clear();

                playerCards.Clear();

                for (int i = 0; i < humanPlayer.playerHand.gethandSize(); i++)
                {
                    CardBox.CardBox newCardBox = new CardBox.CardBox(humanPlayer.playerHand.GetCard(i));
                    newCardBox.Click += CardBox_Click;
                    playerCards.Add(newCardBox);
                }

                ControlDisplayer();
            }
            else
            {
                aiPlayer.DrawCards(gameDeck);

                this.pnAIHand.Controls.Clear();

                aiCards.Clear();

                for (int i = 0; i < aiPlayer.playerHand.gethandSize(); i++)
                {
                    CardBox.CardBox newCardBox = new CardBox.CardBox(aiPlayer.playerHand.GetCard(i));
                    aiCards.Add(newCardBox);
                }

                ControlDisplayer();
            }

            if (gameDeck.getCardsRemaining() == 0)
            {
                gameEnder = true;

            }

            if (gameEnder)
            {
                isGameOver();
            }


            if (defendingPlayer == humanPlayer)
            {
                humanPlayer.DrawCards(gameDeck);

                this.pnPlayerHand.Controls.Clear();

                playerCards.Clear();

                for (int i = 0; i < humanPlayer.playerHand.gethandSize(); i++)
                {
                    CardBox.CardBox newCardBox = new CardBox.CardBox(humanPlayer.playerHand.GetCard(i));
                    newCardBox.Click += CardBox_Click;
                    playerCards.Add(newCardBox);
                }

                ControlDisplayer();
            }
            else
            {
                aiPlayer.DrawCards(gameDeck);

                this.pnAIHand.Controls.Clear();

                aiCards.Clear();

                for (int i = 0; i < aiPlayer.playerHand.gethandSize(); i++)
                {
                    CardBox.CardBox newCardBox = new CardBox.CardBox(aiPlayer.playerHand.GetCard(i));
                    aiCards.Add(newCardBox);
                }

                ControlDisplayer();
            }

            if (gameDeck.getCardsRemaining() == 0)
            {
                gameEnder = true;
            }

            if (gameEnder)
            {
                isGameOver();
            }

            SwapRoles();
            gameLogWriter("Roles Swapped");

            countTurns = 0;
            currPlayer = attackingPlayer;
            currRound = INITIALATTACK;
            flag = false;
            lblPlayerTurn.Text = currPlayer.playerName + " is the new attacker.";
            gameLogWriter(attackingPlayer.playerName + " is the new attacker.");


            lblDeckSizeValue.Text = gameDeck.getCardsRemaining().ToString();

        }

        private void btnDiscardPile_Click(object sender, EventArgs e)
        {
            DiscardForm frmdiscard = new DiscardForm();
            DiscardForm.field = gamePlayingField;
            frmdiscard.ShowDialog();
        }

        public void SwapRoles()
        {
            if (defendingPlayer == humanPlayer)
            {
                defendingPlayer = aiPlayer;
                attackingPlayer = humanPlayer;
            }
            else if (defendingPlayer == aiPlayer)
            {
                defendingPlayer = humanPlayer;
                attackingPlayer = aiPlayer;
            }
        
        }

        private void btnResetStats_Click(object sender, EventArgs e)
        {

            numGamesPlayed = 0;
            wonGames = 0;
            lostGames = 0;
            statLogWriter(humanPlayer.playerName + "\n" + "Games Played: " + numGamesPlayed + "\n" + "Games Won: "
                + wonGames + "\n" + "Games Lost: " + lostGames);
            btnResetStats.Visible = false;

        }

        private void pnAIHand_Paint(object sender, PaintEventArgs e)
        {

        }

        public void statLogReader()
        {
            bool fileExists = false;
            string path = "../../logs/PlayerStats/" + humanPlayer.playerName + "-StatsLog.txt";

            using (FileStream fs = File.Open(path, FileMode.Append, FileAccess.Write))
            {
                if ( fs.Length > 0)
                {
                    fileExists = true;
                   

                    
                }
            }
           
           if(fileExists)
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string input = reader.ReadToEnd();

                    string[] splitInput = input.Split(null);
                    numGamesPlayed = int.Parse(splitInput[3]);
                    wonGames = int.Parse(splitInput[6]);
                    lostGames = int.Parse(splitInput[9]);
                    Console.WriteLine(splitInput[3]);

                }
            }
           
          
        }

        private void pnTrump_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
