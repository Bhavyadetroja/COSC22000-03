using System;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;
using DurakLibrary;

namespace DurakFormApp
{
    public partial class DiscardForm : Form
    {
        public List<CardBox.CardBox> discardPile = new List<CardBox.CardBox>();
        public static GameField field { get; set;}

        public DiscardForm()
        {
            InitializeComponent();
        }

        private void frmDiscard_Load(object sender, EventArgs e)
        {
            DisplayDiscardPile();
        }

        private void DisplayDiscardPile()
        {
            int counter = 0;
            int topOffset = 10;
            int displayCounter = 10;
            ArrayList discardedCards = field.getDiscard();
            for (int i = 0; i < discardedCards.Count; i++)
            {
                CardBox.CardBox newCardBox = new CardBox.CardBox((GameCard)discardedCards[i]);
                discardPile.Add(newCardBox);
            }
            for (int i = discardedCards.Count - 1; i >= 0; i--)
            {
                discardPile[i].Left = (displayCounter * 20) + 100;
                discardPile[i].Top = topOffset;
                counter++;
                displayCounter--;
                this.pnDiscard.Controls.Add(discardPile[i]);
                if (counter > 9)
                {
                    topOffset = topOffset + 120;
                    counter = 0;
                    displayCounter = 10;
                }

            }
        }
    }
}
