using System;
using System.Drawing;
using System.Windows.Forms;
using DurakLibrary;

namespace CardBox
{
    public partial class CardBox: UserControl
    {

        private GameCard myCard;

        private Orientation myOrientation;

        new public event EventHandler Click;

        public event EventHandler CardFlipped;

        public GameRank rank
        {
            set
            {
                Card.rank = value;
                UpdateCardImage();
            }
            get { return Card.rank; }
        }

        private void CardBox_Load(object sender, EventArgs e)
        {
            UpdateCardImage();
        }

        public override string ToString()
        {
            return myCard.ToString();
        }

        private void pbMyPictureBox_Click(object sender, EventArgs e)
        {
            if (Click != null)
                Click(this, e);
        }

        public bool FaceUp
        {
            set
            {
                if (myCard.FaceUp != value)
                {
                    myCard.FaceUp = value;
                    UpdateCardImage();

                    if (CardFlipped != null)
                        CardFlipped(this, new EventArgs());
                }
            }
            get { return Card.FaceUp; }
        }

        public GameCard Card
        {
            set
            {
                myCard = value;
                UpdateCardImage();
            }
            get { return myCard; }
        }

        public GameSuit Suit
        {
            set
            {
                Card.suit = value;
                UpdateCardImage();
            }
            get { return Card.suit; }
        }


        public Orientation CardOrientation
        {
            set
            {             
                if (myOrientation != value)
                {
                    myOrientation = value;
                    this.Size = new Size(Size.Height, Size.Width);
                    UpdateCardImage();
                }
            }
            get { return myOrientation; }
        }

        private void UpdateCardImage()
        {
            pbMyPictureBox.Image = myCard.GetCardImage();

            if(myOrientation == Orientation.Horizontal)
            {
                pbMyPictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
        }

        public CardBox()
        {
            InitializeComponent();
            myOrientation = Orientation.Vertical;
            myCard = new GameCard();
            UpdateCardImage();
        }

        public CardBox(GameCard card, Orientation orientation = Orientation.Vertical)
        {
            InitializeComponent();
            myOrientation = orientation;
            myCard = card;
        }
    }
}
