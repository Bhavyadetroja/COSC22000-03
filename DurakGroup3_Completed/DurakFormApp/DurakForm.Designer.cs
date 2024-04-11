namespace DurakFormApp
{
    partial class DurakForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DurakForm));
            this.lblDeckSize = new System.Windows.Forms.Label();
            this.lblDeckSizeValue = new System.Windows.Forms.Label();
            this.pnPlayerHand = new System.Windows.Forms.Panel();
            this.btnPlayCard = new System.Windows.Forms.Button();
            this.btnSkipTurn = new System.Windows.Forms.Button();
            this.lblCardSelected = new System.Windows.Forms.Label();
            this.pnPlayingField = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuHowToPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDiscardPile = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblPlayerTurn = new System.Windows.Forms.Label();
            this.lblField = new System.Windows.Forms.Label();
            this.lblHand = new System.Windows.Forms.Label();
            this.lblErrorMsg = new System.Windows.Forms.Label();
            this.pnAIHand = new System.Windows.Forms.Panel();
            this.chkAIHandToggle = new System.Windows.Forms.CheckBox();
            this.txtNameInput = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnResetStats = new System.Windows.Forms.Button();
            this.pnTrump = new System.Windows.Forms.Panel();
            this.lblTrumpCard = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDeckSize
            // 
            this.lblDeckSize.BackColor = System.Drawing.Color.Transparent;
            this.lblDeckSize.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeckSize.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDeckSize.Location = new System.Drawing.Point(13, 398);
            this.lblDeckSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDeckSize.Name = "lblDeckSize";
            this.lblDeckSize.Size = new System.Drawing.Size(140, 37);
            this.lblDeckSize.TabIndex = 1;
            this.lblDeckSize.Text = "Deck Size:";
            this.lblDeckSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDeckSizeValue
            // 
            this.lblDeckSizeValue.BackColor = System.Drawing.Color.Transparent;
            this.lblDeckSizeValue.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeckSizeValue.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDeckSizeValue.Location = new System.Drawing.Point(194, 385);
            this.lblDeckSizeValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDeckSizeValue.Name = "lblDeckSizeValue";
            this.lblDeckSizeValue.Size = new System.Drawing.Size(72, 38);
            this.lblDeckSizeValue.TabIndex = 3;
            this.lblDeckSizeValue.Text = "36";
            this.lblDeckSizeValue.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnPlayerHand
            // 
            this.pnPlayerHand.BackColor = System.Drawing.Color.Transparent;
            this.pnPlayerHand.Location = new System.Drawing.Point(317, 530);
            this.pnPlayerHand.Margin = new System.Windows.Forms.Padding(4);
            this.pnPlayerHand.Name = "pnPlayerHand";
            this.pnPlayerHand.Size = new System.Drawing.Size(996, 134);
            this.pnPlayerHand.TabIndex = 4;
            // 
            // btnPlayCard
            // 
            this.btnPlayCard.BackColor = System.Drawing.Color.Transparent;
            this.btnPlayCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayCard.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPlayCard.Location = new System.Drawing.Point(175, 507);
            this.btnPlayCard.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlayCard.Name = "btnPlayCard";
            this.btnPlayCard.Size = new System.Drawing.Size(112, 45);
            this.btnPlayCard.TabIndex = 5;
            this.btnPlayCard.Text = "Play Card";
            this.btnPlayCard.UseVisualStyleBackColor = false;
            this.btnPlayCard.Click += new System.EventHandler(this.btnPlayCard_Click);
            // 
            // btnSkipTurn
            // 
            this.btnSkipTurn.BackColor = System.Drawing.Color.Transparent;
            this.btnSkipTurn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSkipTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSkipTurn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSkipTurn.Location = new System.Drawing.Point(175, 606);
            this.btnSkipTurn.Margin = new System.Windows.Forms.Padding(4);
            this.btnSkipTurn.Name = "btnSkipTurn";
            this.btnSkipTurn.Size = new System.Drawing.Size(112, 38);
            this.btnSkipTurn.TabIndex = 6;
            this.btnSkipTurn.Text = "Skip Turn";
            this.btnSkipTurn.UseVisualStyleBackColor = false;
            this.btnSkipTurn.Click += new System.EventHandler(this.btnSkipTurn_Click);
            // 
            // lblCardSelected
            // 
            this.lblCardSelected.BackColor = System.Drawing.Color.Transparent;
            this.lblCardSelected.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardSelected.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblCardSelected.Location = new System.Drawing.Point(717, 490);
            this.lblCardSelected.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCardSelected.Name = "lblCardSelected";
            this.lblCardSelected.Size = new System.Drawing.Size(577, 37);
            this.lblCardSelected.TabIndex = 7;
            this.lblCardSelected.Text = "Card Selected:";
            this.lblCardSelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnPlayingField
            // 
            this.pnPlayingField.BackColor = System.Drawing.Color.Transparent;
            this.pnPlayingField.Location = new System.Drawing.Point(316, 217);
            this.pnPlayingField.Margin = new System.Windows.Forms.Padding(4);
            this.pnPlayingField.Name = "pnPlayingField";
            this.pnPlayingField.Size = new System.Drawing.Size(997, 268);
            this.pnPlayingField.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHowToPlay,
            this.mnuExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1348, 28);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuHowToPlay
            // 
            this.mnuHowToPlay.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
            this.mnuHowToPlay.Name = "mnuHowToPlay";
            this.mnuHowToPlay.Size = new System.Drawing.Size(105, 24);
            this.mnuHowToPlay.Text = "How To Play";
            this.mnuHowToPlay.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 28);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(47, 24);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // btnDiscardPile
            // 
            this.btnDiscardPile.BackColor = System.Drawing.Color.Transparent;
            this.btnDiscardPile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscardPile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscardPile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDiscardPile.Location = new System.Drawing.Point(175, 560);
            this.btnDiscardPile.Margin = new System.Windows.Forms.Padding(4);
            this.btnDiscardPile.Name = "btnDiscardPile";
            this.btnDiscardPile.Size = new System.Drawing.Size(112, 38);
            this.btnDiscardPile.TabIndex = 14;
            this.btnDiscardPile.Text = "Discard Pile";
            this.btnDiscardPile.UseVisualStyleBackColor = false;
            this.btnDiscardPile.Click += new System.EventHandler(this.btnDiscardPile_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStart.Location = new System.Drawing.Point(175, 455);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 44);
            this.btnStart.TabIndex = 17;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblPlayerTurn
            // 
            this.lblPlayerTurn.AutoSize = true;
            this.lblPlayerTurn.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerTurn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPlayerTurn.Location = new System.Drawing.Point(829, 178);
            this.lblPlayerTurn.Name = "lblPlayerTurn";
            this.lblPlayerTurn.Size = new System.Drawing.Size(138, 29);
            this.lblPlayerTurn.TabIndex = 18;
            this.lblPlayerTurn.Text = "Player turn";
            this.lblPlayerTurn.TextChanged += new System.EventHandler(this.lblPlayerTurn_TextChanged);
            // 
            // lblField
            // 
            this.lblField.AutoSize = true;
            this.lblField.BackColor = System.Drawing.Color.Transparent;
            this.lblField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblField.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblField.Location = new System.Drawing.Point(321, 183);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(59, 25);
            this.lblField.TabIndex = 19;
            this.lblField.Text = "Field";
            // 
            // lblHand
            // 
            this.lblHand.AutoSize = true;
            this.lblHand.BackColor = System.Drawing.Color.Transparent;
            this.lblHand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHand.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblHand.Location = new System.Drawing.Point(321, 498);
            this.lblHand.Name = "lblHand";
            this.lblHand.Size = new System.Drawing.Size(111, 25);
            this.lblHand.TabIndex = 20;
            this.lblHand.Text = "Your hand";
            // 
            // lblErrorMsg
            // 
            this.lblErrorMsg.AutoSize = true;
            this.lblErrorMsg.Location = new System.Drawing.Point(391, 190);
            this.lblErrorMsg.Name = "lblErrorMsg";
            this.lblErrorMsg.Size = new System.Drawing.Size(0, 16);
            this.lblErrorMsg.TabIndex = 23;
            // 
            // pnAIHand
            // 
            this.pnAIHand.BackColor = System.Drawing.Color.Transparent;
            this.pnAIHand.Location = new System.Drawing.Point(316, 27);
            this.pnAIHand.Margin = new System.Windows.Forms.Padding(4);
            this.pnAIHand.Name = "pnAIHand";
            this.pnAIHand.Size = new System.Drawing.Size(997, 134);
            this.pnAIHand.TabIndex = 24;
            this.pnAIHand.Paint += new System.Windows.Forms.PaintEventHandler(this.pnAIHand_Paint);
            // 
            // chkAIHandToggle
            // 
            this.chkAIHandToggle.AutoSize = true;
            this.chkAIHandToggle.BackColor = System.Drawing.Color.Transparent;
            this.chkAIHandToggle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkAIHandToggle.Location = new System.Drawing.Point(79, 295);
            this.chkAIHandToggle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkAIHandToggle.Name = "chkAIHandToggle";
            this.chkAIHandToggle.Size = new System.Drawing.Size(126, 20);
            this.chkAIHandToggle.TabIndex = 25;
            this.chkAIHandToggle.Text = "Display AI Hand";
            this.chkAIHandToggle.UseVisualStyleBackColor = false;
            this.chkAIHandToggle.CheckedChanged += new System.EventHandler(this.chkAIHandToggle_CheckedChanged);
            // 
            // txtNameInput
            // 
            this.txtNameInput.Location = new System.Drawing.Point(72, 257);
            this.txtNameInput.Margin = new System.Windows.Forms.Padding(4);
            this.txtNameInput.Name = "txtNameInput";
            this.txtNameInput.Size = new System.Drawing.Size(132, 22);
            this.txtNameInput.TabIndex = 26;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnResetStats
            // 
            this.btnResetStats.BackColor = System.Drawing.Color.Transparent;
            this.btnResetStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetStats.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnResetStats.Location = new System.Drawing.Point(72, 334);
            this.btnResetStats.Margin = new System.Windows.Forms.Padding(4);
            this.btnResetStats.Name = "btnResetStats";
            this.btnResetStats.Size = new System.Drawing.Size(107, 37);
            this.btnResetStats.TabIndex = 28;
            this.btnResetStats.Text = "Reset Stats";
            this.btnResetStats.UseVisualStyleBackColor = false;
            this.btnResetStats.Visible = false;
            this.btnResetStats.Click += new System.EventHandler(this.btnResetStats_Click);
            // 
            // pnTrump
            // 
            this.pnTrump.BackColor = System.Drawing.Color.Transparent;
            this.pnTrump.Location = new System.Drawing.Point(72, 103);
            this.pnTrump.Margin = new System.Windows.Forms.Padding(4);
            this.pnTrump.Name = "pnTrump";
            this.pnTrump.Size = new System.Drawing.Size(187, 137);
            this.pnTrump.TabIndex = 25;
            this.pnTrump.Paint += new System.Windows.Forms.PaintEventHandler(this.pnTrump_Paint);
            // 
            // lblTrumpCard
            // 
            this.lblTrumpCard.BackColor = System.Drawing.Color.Transparent;
            this.lblTrumpCard.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrumpCard.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTrumpCard.Location = new System.Drawing.Point(0, 28);
            this.lblTrumpCard.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrumpCard.Name = "lblTrumpCard";
            this.lblTrumpCard.Size = new System.Drawing.Size(318, 71);
            this.lblTrumpCard.TabIndex = 11;
            this.lblTrumpCard.Text = "Trump Card:";
            this.lblTrumpCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DurakForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1348, 683);
            this.Controls.Add(this.pnTrump);
            this.Controls.Add(this.btnResetStats);
            this.Controls.Add(this.txtNameInput);
            this.Controls.Add(this.chkAIHandToggle);
            this.Controls.Add(this.pnPlayingField);
            this.Controls.Add(this.pnAIHand);
            this.Controls.Add(this.lblErrorMsg);
            this.Controls.Add(this.lblHand);
            this.Controls.Add(this.lblField);
            this.Controls.Add(this.lblPlayerTurn);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnDiscardPile);
            this.Controls.Add(this.lblTrumpCard);
            this.Controls.Add(this.lblCardSelected);
            this.Controls.Add(this.btnSkipTurn);
            this.Controls.Add(this.btnPlayCard);
            this.Controls.Add(this.pnPlayerHand);
            this.Controls.Add(this.lblDeckSizeValue);
            this.Controls.Add(this.lblDeckSize);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DurakForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Durak";
            this.Load += new System.EventHandler(this.frmDurak_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDeckSize;
        private System.Windows.Forms.Label lblDeckSizeValue;
        private System.Windows.Forms.Panel pnPlayerHand;
        private System.Windows.Forms.Button btnPlayCard;
        private System.Windows.Forms.Button btnSkipTurn;
        private System.Windows.Forms.Label lblCardSelected;
        private System.Windows.Forms.Panel pnPlayingField;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuHowToPlay;
        private System.Windows.Forms.Button btnDiscardPile;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private CardBox.CardBox cbTrumpCard;
        private CardBox.CardBox cardBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblPlayerTurn;
        private System.Windows.Forms.Label lblField;
        private System.Windows.Forms.Label lblHand;
        private System.Windows.Forms.Label lblErrorMsg;
        private System.Windows.Forms.Panel pnAIHand;
        private System.Windows.Forms.CheckBox chkAIHandToggle;
        private System.Windows.Forms.TextBox txtNameInput;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnResetStats;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.Panel pnTrump;
        private System.Windows.Forms.Label lblTrumpCard;
    }
}

