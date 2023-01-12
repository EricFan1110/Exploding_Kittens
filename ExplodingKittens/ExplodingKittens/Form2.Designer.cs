namespace ExplodingKittens
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Play = new System.Windows.Forms.Button();
            this.NumofPlayed = new System.Windows.Forms.Label();
            this.EndTurn = new System.Windows.Forms.Button();
            this.P1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.P2 = new System.Windows.Forms.Button();
            this.P3 = new System.Windows.Forms.Button();
            this.P4 = new System.Windows.Forms.Button();
            this.P2CardNum = new System.Windows.Forms.Label();
            this.P3CardNum = new System.Windows.Forms.Label();
            this.P4CardNum = new System.Windows.Forms.Label();
            this.Give = new System.Windows.Forms.Button();
            this.DeckCardCount = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.P1DEAD = new System.Windows.Forms.PictureBox();
            this.P1Bomb = new System.Windows.Forms.PictureBox();
            this.P4Bomb = new System.Windows.Forms.PictureBox();
            this.P3Bomb = new System.Windows.Forms.PictureBox();
            this.P2Bomb = new System.Windows.Forms.PictureBox();
            this.DOWN = new System.Windows.Forms.PictureBox();
            this.LEFT = new System.Windows.Forms.PictureBox();
            this.RIGHT = new System.Windows.Forms.PictureBox();
            this.UP = new System.Windows.Forms.PictureBox();
            this.PlayedCard = new System.Windows.Forms.PictureBox();
            this.P2DEAD = new System.Windows.Forms.PictureBox();
            this.P3DEAD = new System.Windows.Forms.PictureBox();
            this.P4DEAD = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.P1DEAD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P1Bomb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P4Bomb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P3Bomb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P2Bomb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DOWN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LEFT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RIGHT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayedCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P2DEAD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P3DEAD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P4DEAD)).BeginInit();
            this.SuspendLayout();
            // 
            // Play
            // 
            this.Play.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Play.Location = new System.Drawing.Point(1120, 665);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(81, 34);
            this.Play.TabIndex = 0;
            this.Play.Text = "Play";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // NumofPlayed
            // 
            this.NumofPlayed.AutoSize = true;
            this.NumofPlayed.Font = new System.Drawing.Font("TeamViewer14", 15F, System.Drawing.FontStyle.Bold);
            this.NumofPlayed.Location = new System.Drawing.Point(464, 150);
            this.NumofPlayed.Name = "NumofPlayed";
            this.NumofPlayed.Size = new System.Drawing.Size(0, 21);
            this.NumofPlayed.TabIndex = 2;
            // 
            // EndTurn
            // 
            this.EndTurn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EndTurn.Enabled = false;
            this.EndTurn.Location = new System.Drawing.Point(1120, 623);
            this.EndTurn.Name = "EndTurn";
            this.EndTurn.Size = new System.Drawing.Size(81, 36);
            this.EndTurn.TabIndex = 3;
            this.EndTurn.Text = "Draw";
            this.EndTurn.UseVisualStyleBackColor = true;
            this.EndTurn.Click += new System.EventHandler(this.EndTurn_Click);
            // 
            // P1
            // 
            this.P1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.P1.AutoSize = true;
            this.P1.Font = new System.Drawing.Font("Sitka Heading", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1.Location = new System.Drawing.Point(599, 683);
            this.P1.Name = "P1";
            this.P1.Size = new System.Drawing.Size(29, 28);
            this.P1.TabIndex = 4;
            this.P1.Text = "P1";
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // P2
            // 
            this.P2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.P2.Enabled = false;
            this.P2.Font = new System.Drawing.Font("Sitka Heading", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2.Location = new System.Drawing.Point(167, 226);
            this.P2.Name = "P2";
            this.P2.Size = new System.Drawing.Size(94, 39);
            this.P2.TabIndex = 5;
            this.P2.Text = "P2";
            this.P2.UseVisualStyleBackColor = true;
            this.P2.Click += new System.EventHandler(this.ChoosePlayer);
            // 
            // P3
            // 
            this.P3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.P3.Enabled = false;
            this.P3.Font = new System.Drawing.Font("Sitka Heading", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P3.Location = new System.Drawing.Point(560, 22);
            this.P3.Name = "P3";
            this.P3.Size = new System.Drawing.Size(94, 39);
            this.P3.TabIndex = 6;
            this.P3.Text = "P3";
            this.P3.UseVisualStyleBackColor = true;
            this.P3.Click += new System.EventHandler(this.ChoosePlayer);
            // 
            // P4
            // 
            this.P4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.P4.Enabled = false;
            this.P4.Font = new System.Drawing.Font("Sitka Heading", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P4.Location = new System.Drawing.Point(977, 226);
            this.P4.Name = "P4";
            this.P4.Size = new System.Drawing.Size(94, 39);
            this.P4.TabIndex = 7;
            this.P4.Text = "P4";
            this.P4.UseVisualStyleBackColor = true;
            this.P4.Click += new System.EventHandler(this.ChoosePlayer);
            // 
            // P2CardNum
            // 
            this.P2CardNum.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.P2CardNum.AutoSize = true;
            this.P2CardNum.Location = new System.Drawing.Point(202, 268);
            this.P2CardNum.Name = "P2CardNum";
            this.P2CardNum.Size = new System.Drawing.Size(59, 12);
            this.P2CardNum.TabIndex = 8;
            this.P2CardNum.Text = "P2CardNum";
            // 
            // P3CardNum
            // 
            this.P3CardNum.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.P3CardNum.AutoSize = true;
            this.P3CardNum.Location = new System.Drawing.Point(595, 64);
            this.P3CardNum.Name = "P3CardNum";
            this.P3CardNum.Size = new System.Drawing.Size(59, 12);
            this.P3CardNum.TabIndex = 9;
            this.P3CardNum.Text = "P3CardNum";
            // 
            // P4CardNum
            // 
            this.P4CardNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.P4CardNum.AutoSize = true;
            this.P4CardNum.Location = new System.Drawing.Point(1012, 268);
            this.P4CardNum.Name = "P4CardNum";
            this.P4CardNum.Size = new System.Drawing.Size(59, 12);
            this.P4CardNum.TabIndex = 10;
            this.P4CardNum.Text = "P4CardNum";
            // 
            // Give
            // 
            this.Give.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Give.Enabled = false;
            this.Give.Location = new System.Drawing.Point(1033, 665);
            this.Give.Name = "Give";
            this.Give.Size = new System.Drawing.Size(81, 33);
            this.Give.TabIndex = 11;
            this.Give.Text = "Give";
            this.Give.UseVisualStyleBackColor = true;
            this.Give.Click += new System.EventHandler(this.Give_Click);
            // 
            // DeckCardCount
            // 
            this.DeckCardCount.AutoSize = true;
            this.DeckCardCount.Location = new System.Drawing.Point(687, 159);
            this.DeckCardCount.Name = "DeckCardCount";
            this.DeckCardCount.Size = new System.Drawing.Size(0, 12);
            this.DeckCardCount.TabIndex = 12;
            // 
            // timer2
            // 
            this.timer2.Interval = 4000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // P1DEAD
            // 
            this.P1DEAD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.P1DEAD.Image = global::ExplodingKittens.Properties.Resources.DEADSKULL;
            this.P1DEAD.Location = new System.Drawing.Point(1033, 528);
            this.P1DEAD.Name = "P1DEAD";
            this.P1DEAD.Size = new System.Drawing.Size(170, 170);
            this.P1DEAD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.P1DEAD.TabIndex = 21;
            this.P1DEAD.TabStop = false;
            this.P1DEAD.Visible = false;
            // 
            // P1Bomb
            // 
            this.P1Bomb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.P1Bomb.Image = global::ExplodingKittens.Properties.Resources.Death_Bomb;
            this.P1Bomb.Location = new System.Drawing.Point(973, 644);
            this.P1Bomb.Name = "P1Bomb";
            this.P1Bomb.Size = new System.Drawing.Size(54, 54);
            this.P1Bomb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.P1Bomb.TabIndex = 20;
            this.P1Bomb.TabStop = false;
            this.P1Bomb.Visible = false;
            // 
            // P4Bomb
            // 
            this.P4Bomb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.P4Bomb.Image = global::ExplodingKittens.Properties.Resources.Death_Bomb;
            this.P4Bomb.Location = new System.Drawing.Point(1077, 215);
            this.P4Bomb.Name = "P4Bomb";
            this.P4Bomb.Size = new System.Drawing.Size(54, 54);
            this.P4Bomb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.P4Bomb.TabIndex = 19;
            this.P4Bomb.TabStop = false;
            this.P4Bomb.Visible = false;
            // 
            // P3Bomb
            // 
            this.P3Bomb.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.P3Bomb.Image = global::ExplodingKittens.Properties.Resources.Death_Bomb;
            this.P3Bomb.Location = new System.Drawing.Point(500, 22);
            this.P3Bomb.Name = "P3Bomb";
            this.P3Bomb.Size = new System.Drawing.Size(54, 54);
            this.P3Bomb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.P3Bomb.TabIndex = 18;
            this.P3Bomb.TabStop = false;
            this.P3Bomb.Visible = false;
            // 
            // P2Bomb
            // 
            this.P2Bomb.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.P2Bomb.Image = global::ExplodingKittens.Properties.Resources.Death_Bomb;
            this.P2Bomb.Location = new System.Drawing.Point(107, 226);
            this.P2Bomb.Name = "P2Bomb";
            this.P2Bomb.Size = new System.Drawing.Size(54, 54);
            this.P2Bomb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.P2Bomb.TabIndex = 17;
            this.P2Bomb.TabStop = false;
            this.P2Bomb.Visible = false;
            // 
            // DOWN
            // 
            this.DOWN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DOWN.Image = global::ExplodingKittens.Properties.Resources.Down;
            this.DOWN.Location = new System.Drawing.Point(582, 364);
            this.DOWN.Name = "DOWN";
            this.DOWN.Size = new System.Drawing.Size(46, 43);
            this.DOWN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DOWN.TabIndex = 16;
            this.DOWN.TabStop = false;
            this.DOWN.Visible = false;
            // 
            // LEFT
            // 
            this.LEFT.Image = global::ExplodingKittens.Properties.Resources.Left;
            this.LEFT.Location = new System.Drawing.Point(339, 226);
            this.LEFT.Name = "LEFT";
            this.LEFT.Size = new System.Drawing.Size(46, 43);
            this.LEFT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LEFT.TabIndex = 15;
            this.LEFT.TabStop = false;
            this.LEFT.Visible = false;
            // 
            // RIGHT
            // 
            this.RIGHT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RIGHT.Image = global::ExplodingKittens.Properties.Resources.Right;
            this.RIGHT.Location = new System.Drawing.Point(841, 226);
            this.RIGHT.Name = "RIGHT";
            this.RIGHT.Size = new System.Drawing.Size(46, 43);
            this.RIGHT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RIGHT.TabIndex = 14;
            this.RIGHT.TabStop = false;
            this.RIGHT.Visible = false;
            // 
            // UP
            // 
            this.UP.Image = global::ExplodingKittens.Properties.Resources.Up;
            this.UP.Location = new System.Drawing.Point(582, 92);
            this.UP.Name = "UP";
            this.UP.Size = new System.Drawing.Size(46, 43);
            this.UP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UP.TabIndex = 13;
            this.UP.TabStop = false;
            this.UP.Visible = false;
            // 
            // PlayedCard
            // 
            this.PlayedCard.Location = new System.Drawing.Point(540, 150);
            this.PlayedCard.Name = "PlayedCard";
            this.PlayedCard.Size = new System.Drawing.Size(141, 208);
            this.PlayedCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PlayedCard.TabIndex = 1;
            this.PlayedCard.TabStop = false;
            // 
            // P2DEAD
            // 
            this.P2DEAD.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.P2DEAD.Image = global::ExplodingKittens.Properties.Resources.DEADSKULL;
            this.P2DEAD.Location = new System.Drawing.Point(107, 286);
            this.P2DEAD.Name = "P2DEAD";
            this.P2DEAD.Size = new System.Drawing.Size(100, 100);
            this.P2DEAD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.P2DEAD.TabIndex = 22;
            this.P2DEAD.TabStop = false;
            this.P2DEAD.Visible = false;
            // 
            // P3DEAD
            // 
            this.P3DEAD.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.P3DEAD.Image = global::ExplodingKittens.Properties.Resources.DEADSKULL;
            this.P3DEAD.Location = new System.Drawing.Point(394, 12);
            this.P3DEAD.Name = "P3DEAD";
            this.P3DEAD.Size = new System.Drawing.Size(100, 100);
            this.P3DEAD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.P3DEAD.TabIndex = 23;
            this.P3DEAD.TabStop = false;
            this.P3DEAD.Visible = false;
            // 
            // P4DEAD
            // 
            this.P4DEAD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.P4DEAD.Image = global::ExplodingKittens.Properties.Resources.DEADSKULL;
            this.P4DEAD.Location = new System.Drawing.Point(1031, 286);
            this.P4DEAD.Name = "P4DEAD";
            this.P4DEAD.Size = new System.Drawing.Size(100, 100);
            this.P4DEAD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.P4DEAD.TabIndex = 24;
            this.P4DEAD.TabStop = false;
            this.P4DEAD.Visible = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 711);
            this.Controls.Add(this.P4DEAD);
            this.Controls.Add(this.P3DEAD);
            this.Controls.Add(this.P2DEAD);
            this.Controls.Add(this.P1DEAD);
            this.Controls.Add(this.P1Bomb);
            this.Controls.Add(this.P4Bomb);
            this.Controls.Add(this.P3Bomb);
            this.Controls.Add(this.P2Bomb);
            this.Controls.Add(this.DOWN);
            this.Controls.Add(this.LEFT);
            this.Controls.Add(this.RIGHT);
            this.Controls.Add(this.UP);
            this.Controls.Add(this.DeckCardCount);
            this.Controls.Add(this.Give);
            this.Controls.Add(this.P4CardNum);
            this.Controls.Add(this.P3CardNum);
            this.Controls.Add(this.P2CardNum);
            this.Controls.Add(this.P4);
            this.Controls.Add(this.P3);
            this.Controls.Add(this.P2);
            this.Controls.Add(this.P1);
            this.Controls.Add(this.EndTurn);
            this.Controls.Add(this.NumofPlayed);
            this.Controls.Add(this.PlayedCard);
            this.Controls.Add(this.Play);
            this.Name = "Form2";
            this.Text = "Exploding Kittens";
            ((System.ComponentModel.ISupportInitialize)(this.P1DEAD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P1Bomb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P4Bomb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P3Bomb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P2Bomb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DOWN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LEFT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RIGHT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayedCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P2DEAD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P3DEAD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P4DEAD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.PictureBox PlayedCard;
        private System.Windows.Forms.Label NumofPlayed;
        private System.Windows.Forms.Button EndTurn;
        private System.Windows.Forms.Label P1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button P2;
        private System.Windows.Forms.Button P3;
        private System.Windows.Forms.Button P4;
        private System.Windows.Forms.Label P2CardNum;
        private System.Windows.Forms.Label P3CardNum;
        private System.Windows.Forms.Label P4CardNum;
        private System.Windows.Forms.Button Give;
        private System.Windows.Forms.Label DeckCardCount;
        private System.Windows.Forms.PictureBox UP;
        private System.Windows.Forms.PictureBox RIGHT;
        private System.Windows.Forms.PictureBox LEFT;
        private System.Windows.Forms.PictureBox DOWN;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox P2Bomb;
        private System.Windows.Forms.PictureBox P3Bomb;
        private System.Windows.Forms.PictureBox P4Bomb;
        private System.Windows.Forms.PictureBox P1Bomb;
        private System.Windows.Forms.PictureBox P1DEAD;
        private System.Windows.Forms.PictureBox P2DEAD;
        private System.Windows.Forms.PictureBox P3DEAD;
        private System.Windows.Forms.PictureBox P4DEAD;

    }
}