using System;
using System.Collections;
using System.Text;

namespace DurakLibrary
{
    public class GameField
    {
        private ArrayList field = new ArrayList();
        private ArrayList discard = new ArrayList();

        public GameField()
        {
        }

        public ArrayList getField()
        {
            ArrayList fieldCards = new ArrayList();

            if (field.Count > 0)
            {
               for (int i = 0; i < field.Count; i++)
               {
                  fieldCards.Add((GameCard)field[i]);
               }
            }
            else
            {
                Console.WriteLine("Field is empty.");
            }
            return fieldCards;
        }

        public void cardPlayed(GameCard card)
        {
            field.Add(card);
        }

        public GameCard getCurrentCard()
        {
            GameCard currentCard;

            currentCard = ((GameCard)field[field.Count-1]);

            return currentCard;
        }

        public GameCard getIndexCard(int index)
        {
            GameCard indexCard;

            indexCard = ((GameCard)field[index]);

            return indexCard;
        }

        public ArrayList getDiscard()
        {
            ArrayList discardCards = new ArrayList();
            if (discard.Count > 0)
            {
                for (int i = 0; i < discard.Count; i++)
                {
                    discardCards.Add((GameCard)discard[i]);
                }
            }
            else
            {
                Console.WriteLine("discard is empty.");
            }
            return discardCards;
        }

        public void discardField()
        {
            if (field.Count > 0)
            {
                for (int i = 0; i < field.Count; i++)
                {
                    discard.Add((GameCard)field[i]);
                }
            }
            else
            {
                Console.WriteLine("Field is empty.");
            }
            field.Clear();
        }

        public ArrayList pickupField()
        {
            ArrayList pickupCards = new ArrayList();
            pickupCards = getField();
            field.Clear();
            return pickupCards;

        }

        public void displayField()
        {
            for (int i = 0; i < this.getField().Count; i++)
            {
                GameCard tempCard = (GameCard)this.getField()[i];
                Console.Write(tempCard.ToString());
                if (i != this.getField().Count - 1)
                {
                    Console.Write(", ");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }

        public void displayDiscarded()
        {
            for (int i = 0; i < this.getDiscard().Count; i++)
            {
                GameCard tempCard = (GameCard)this.getDiscard()[i];
                Console.Write(tempCard.ToString());
                if (i != this.getDiscard().Count - 1)
                {
                    Console.Write(", ");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }

    }

    public class GameHand
    {
        public static int defaultHandSize = 6;
        private ArrayList hand = new ArrayList(defaultHandSize);

        public GameHand(GameDeck deck)
        {
            for (int i = 0; i < defaultHandSize; i++)
            {
                hand.Add(deck.drawCard());
            }
        }

        private GameHand()
        {
        }

        public GameCard GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= hand.Count - 1)
            {
                return (GameCard)hand[cardNum];
            }
            else
            {
                throw new ArgumentOutOfRangeException("cardNum", cardNum, "Value must be between 0 and hand size - 1");
            }
        }

        public int gethandSize()
        {
            return hand.Count;
        }

        public GameCard playCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= hand.Count - 1)
            {
                GameCard playedCard = (GameCard)hand[cardNum];
                hand.RemoveAt(cardNum);
                return playedCard;
            }
            else
            {
                throw new ArgumentOutOfRangeException("cardNum", cardNum, "Value must be between 0 and hand size - 1");
            }
        }

        public GameCard selectCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= hand.Count - 1)
            {
                return (GameCard)hand[cardNum];
            }
            else
            {
                throw new ArgumentOutOfRangeException("cardNum", cardNum, "Value must be between 0 and hand size - 1");
            }
        }

        public void removeHand()
        {
            hand.Clear();
        }

        public void addCard(GameCard card)
        {
            hand.Add(card);
        }

        public void displayHand()
        {
            for (int i = 0; i < this.gethandSize(); i++)
            {
                GameCard tempCard = this.GetCard(i);
                Console.Write(tempCard.ToString());
                Console.Write((i != this.gethandSize() - 1) ? ", " : "\n");
            }
        }

        public override string ToString()
        {
            StringBuilder tempString = new StringBuilder();
            for (int i = 0; i < this.gethandSize(); i++)
            {
                GameCard tempCard = this.GetCard(i);
                tempString.Append(" " + tempCard.ToString());
            }
            return tempString.ToString();
        }

        public GameCard getMinOfSuite(GameCard gameCard)
        {
            int minOfSuite = -1;
            GameCard minCard = null;

            for (int i = 0; i < this.gethandSize(); i++)
            {
                if (gameCard.suit == this.GetCard(i).suit)
                {
                    if (minOfSuite == -1)
                    {
                        minOfSuite = (int) this.GetCard(i).rank;
                        minCard = this.GetCard(i);
                    }
                    else if (minOfSuite > (int) this.GetCard(i).rank)
                    {
                        minOfSuite = (int)this.GetCard(i).rank;
                        minCard = this.GetCard(i);
                    }
                }
            }
            return minCard;
        }

        public GameCard getMaxOfSuite(GameSuit suit)
        {
            int maxOfSuite = -1;
            GameCard maxCard = null;

            for (int i = 0; i < this.gethandSize(); i++)
            {
                if (suit == this.GetCard(i).suit)
                {
                    if (maxOfSuite == -1)
                    {
                        maxOfSuite = (int)this.GetCard(i).rank;
                        maxCard = this.GetCard(i);
                    }
                    else if (maxOfSuite < (int)this.GetCard(i).rank)
                    {
                        maxOfSuite = (int)this.GetCard(i).rank;
                        maxCard = this.GetCard(i);
                    }
                }
            }
            return maxCard;
        }
    }

    public class GameDeck
    {
        public static int cardsInDeck = 36;
        private ArrayList cards = new ArrayList(cardsInDeck);

        public GameDeck()
        {
            int cardValue = 1;
            int initialValue = 1;
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                cardValue = initialValue;
                initialValue++;
                for (int rankVal = 1; rankVal < 10; rankVal++)
                {
                    cards.Add(new GameCard((GameSuit)suitVal, (GameRank)rankVal, cardValue));
                    cardValue = cardValue + 4;
                }
            }
        }

        public GameCard GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= cardsInDeck - 1)
            {
                return (GameCard)cards[cardNum];
            }
            else
            {
                throw (new System.ArgumentOutOfRangeException("cardNum", cardNum, "Value must be between 0 and 36."));
            }
        }

        public void Shuffle()
        {
            GameCard[] newDeck = new GameCard[cardsInDeck];
            bool[] assigned = new bool[cardsInDeck];
            Random sourceGen = new Random();

            for (int i = 0; i < cardsInDeck; i++)
            {
                int destCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    destCard = sourceGen.Next(cardsInDeck);
                    if (assigned[destCard] == false)
                    {
                        foundCard = true;
                    }
                }
                assigned[destCard] = true;
                newDeck[destCard] = (GameCard)cards[i];
            }
            cards = new ArrayList(newDeck);
        }

        public int getCardsRemaining()
        {
            int cardsRemaining = cards.Count;
            return cardsRemaining;
        }

        public GameCard getTrumpcard()
        {
            GameCard trumpCard = new GameCard((GameCard)cards[0]);

            this.cards.RemoveAt(0);

            return trumpCard;
        }

        public GameCard drawCard()
        {
            GameCard drawnCard = new GameCard((GameCard)cards[cards.Count - 1]);

            cards.RemoveAt(cards.Count - 1);

            return drawnCard;
        }

        public void displayDeck(GameDeck myDeck)
        {
            for (int i = 0; i < myDeck.getCardsRemaining(); i++)
            {
                GameCard tempCard = myDeck.GetCard(i);
                Console.Write(tempCard.ToString());
                if (i != myDeck.getCardsRemaining() - 1)
                {
                    Console.Write(", ");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
