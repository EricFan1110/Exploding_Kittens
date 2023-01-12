using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExplodingKittens
{
    public partial class Form3 : Form
    {
        public string selectedtype { get; set; }
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string[] types = { "DEFUSE", "CATTERMELON", "BEARD_CAT", "HAIRY_POTATO_CAT", "TACOCAT", "RAINBOW", 
                                              "ATTACK", "SHUFFLE", "FAVOR", "SKIP", "SEE_THE_FUTURE", "NOPE" };
            string imagePath = @"Cards/";
            int position = 10;
            int py = 10;
            foreach (string type in types)
            {
                PictureBox pb = new PictureBox();
                pb.Width = 100;
                pb.Height = 150;
                pb.BorderStyle = BorderStyle.Fixed3D;
                pb.Image = Image.FromFile(imagePath + type + ".png");
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Name = type;
                pb.Click += Picture_Click;

                pb.Location = new Point(position, py);
                position += 110;
                this.Controls.Add(pb);

                if (position > 600) 
                {
                    position = 10;
                    py += 160;
                }
            }
        }
        private void Picture_Click(object sender, EventArgs e)
        {
            selectedtype = (sender as PictureBox).Name;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
