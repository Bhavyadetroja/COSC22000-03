using System;
using System.IO;

namespace DurakLibrary
{
    public class Player
    {
        public string playerName { get; set; }

        public GameHand playerHand { get; set; }


        public Player(string name)
        {
            playerName = name;
        }

        public void DrawCards(GameDeck myDeck)
        {
            bool attackerDraw = true;
            string filePath = @"../../GameLog.txt";
            string tempString = "";

            while (attackerDraw)
            {
                if (myDeck.getCardsRemaining() > 0)
                {
                    int attackerHandSize = this.playerHand.gethandSize();
                    if (attackerHandSize < 6)
                    {
                        GameCard drawnCard = myDeck.drawCard();
                        tempString += " " + drawnCard.ToString();
                     
                        this.playerHand.addCard(drawnCard);
                    

                    }
                    else
                    {
                        attackerDraw = false;

                    }
                }
                else
                {
                    attackerDraw = false;

                }
            }
            if(tempString != "")
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {

                    writer.WriteLine(this.playerName + " drew:" + tempString);

                }
            }
          

        }


    }

    public class AI : Player
    {
        const int TURNSKIPPED = -1;

        public AI(string name) : base(name)
        {
            playerName = name;
        }

        public int AITurnCycle(GameCard TrumpCard, GameField PlayingField, string round, bool perevodnoyFlag)
        {
            const string ATTACKINITIAL = "INITIALATTACK";
            const string ATTACKERTURN = "PLAYATTACKER";
            const string DEFENDERTURN = "PLAYDEFENDER";

            if (round == ATTACKINITIAL)
            {
                return AIAttackerInitialTurn(TrumpCard);
            }
            else if (round == ATTACKERTURN)
            {
                return AIAttackerTurn(PlayingField, TrumpCard);
            }
            else if (round == DEFENDERTURN)
            {
                return AIDefenderTurn(PlayingField, TrumpCard, perevodnoyFlag);
            }
            else
            {
                return TURNSKIPPED;
            }
        }

        public int AIAttackerInitialTurn(GameCard trumpCard)
        {
            GameCard selectedCard = null;

            // Finding the highest card that is not a trump
            foreach (GameSuit suit in Enum.GetValues(typeof(GameSuit)))
            {
                if (suit != trumpCard.suit)
                {
                    GameCard gameCard = this.playerHand.getMaxOfSuite(suit);

                    if (gameCard != null)
                    {
                        if (selectedCard == null)
                        {
                            selectedCard = gameCard;
                        }
                        else if ((int) selectedCard.rank < (int) gameCard.rank)
                        {
                            selectedCard = gameCard;
                        }
                    }
                }
            }

            if (selectedCard == null)
            {
                // All cards in hand are of the trump suit.
                selectedCard = this.playerHand.getMinOfSuite(trumpCard);
            }

            // Finding the index of selected card
            for (int i = 0; i < this.playerHand.gethandSize(); i++)
            {
                if (this.playerHand.GetCard(i) == selectedCard)
                {
                    return i;
                }
            }
            // Couldnt select any card.
            return -1;
        }

        public int AIAttackerTurn(GameField playingField, GameCard trumpCard)
        {
            // Finding the highest card of the required suit.
            GameCard selectedCard = this.playerHand.getMaxOfSuite(playingField.getCurrentCard().suit);

            if (selectedCard == null)
            {
                selectedCard = this.playerHand.getMinOfSuite(trumpCard);
            }
            else if ((int) selectedCard.rank < (int) playingField.getCurrentCard().rank)
            {
                selectedCard = this.playerHand.getMinOfSuite(trumpCard);
            }

            // Finding the index of selected card
            for (int i = 0; i < this.playerHand.gethandSize(); i++)
            {
                if (this.playerHand.GetCard(i) == selectedCard)
                {
                    return i;
                }
            }
            // Couldnt select any card.
            return -1;
        }

        public int AIDefenderTurn(GameField playingField, GameCard trumpCard, bool perevodnoyFlag)
        {
            // Finding the highest card of the required suit.
            GameCard selectedCard = this.playerHand.getMaxOfSuite(playingField.getCurrentCard().suit);

            if (selectedCard == null)
            {
                selectedCard = this.playerHand.getMinOfSuite(trumpCard);
            }
            else if ((int)selectedCard.rank < (int)playingField.getCurrentCard().rank)
            {
                selectedCard = this.playerHand.getMinOfSuite(trumpCard);
            }

            // Finding the index of selected card
            for (int i = 0; i < this.playerHand.gethandSize(); i++)
            {
                if (this.playerHand.GetCard(i) == selectedCard)
                {
                    return i;
                }
            }
            // Couldnt select any card.
            return -1;
        }
    }
}
