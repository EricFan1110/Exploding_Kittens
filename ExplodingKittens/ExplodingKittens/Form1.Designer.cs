namespace ExplodingKittens
{
    partial class Form1
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
            this.NName = new System.Windows.Forms.TextBox();
            this.Nick = new System.Windows.Forms.Label();
            this.init = new System.Windows.Forms.Button();
            this.info = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NName
            // 
            this.NName.Location = new System.Drawing.Point(181, 86);
            this.NName.Name = "NName";
            this.NName.Size = new System.Drawing.Size(226, 21);
            this.NName.TabIndex = 0;
            // 
            // Nick
            // 
            this.Nick.AutoSize = true;
            this.Nick.Location = new System.Drawing.Point(77, 89);
            this.Nick.Name = "Nick";
            this.Nick.Size = new System.Drawing.Size(53, 12);
            this.Nick.TabIndex = 1;
            this.Nick.Text = "Nickname";
            // 
            // init
            // 
            this.init.Location = new System.Drawing.Point(489, 83);
            this.init.Name = "init";
            this.init.Size = new System.Drawing.Size(98, 23);
            this.init.TabIndex = 2;
            this.init.Text = "Find Game";
            this.init.UseVisualStyleBackColor = true;
            this.init.Click += new System.EventHandler(this.init_Click);
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Location = new System.Drawing.Point(385, 347);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(0, 12);
            this.info.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name cannot contain spaces";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 207);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.info);
            this.Controls.Add(this.init);
            this.Controls.Add(this.Nick);
            this.Controls.Add(this.NName);
            this.Name = "Form1";
            this.Text = "Exploding Kittens";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NName;
        private System.Windows.Forms.Label Nick;
        private System.Windows.Forms.Button init;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Label label1;
    }
}

