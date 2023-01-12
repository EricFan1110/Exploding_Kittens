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
    public partial class Form4 : Form
    {
        string imagePath = @"Cards/";
        public Form4(string type1, string type2, string type3)
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(imagePath + type1 + ".png");
            pictureBox2.Image = Image.FromFile(imagePath + type2 + ".png");
            pictureBox3.Image = Image.FromFile(imagePath + type3 + ".png");
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
