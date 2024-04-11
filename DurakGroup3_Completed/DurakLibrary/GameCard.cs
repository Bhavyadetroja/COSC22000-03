using System.Drawing;

namespace DurakLibrary
{
    public class GameCard
    {
        public GameSuit suit;
        public GameRank rank;
        public readonly int value;
        public static GameSuit trump;
        public static GameRank trumpRank;
        protected bool faceUp = true;

        public bool FaceUp
        {
            get { return faceUp; }
            set { faceUp = value; }
        }

        public GameCard(GameSuit newSuit, GameRank newRank, int newValue)
        {
            suit = newSuit;
            rank = newRank;
            value = newValue;
        }

        public GameCard(GameCard card)
        {
            suit = card.suit;
            rank = card.rank;
            value = card.value;
        }

        public GameCard() { }

        public override string ToString()
        {
            return "The " + rank + " of " + suit;
        }

        public Image GetCardImage()
        {
            string imageName;
            Image cardImage;

            if (!faceUp)
            {
                imageName = "purple_back";
            }
            else
            {
                imageName = suit.ToString() + "_" + rank.ToString();
            }
            cardImage = Properties.Resources.ResourceManager.GetObject(imageName) as Image;
            return cardImage;
        }
    }
}
