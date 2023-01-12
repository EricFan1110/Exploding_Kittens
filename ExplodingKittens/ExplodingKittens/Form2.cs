using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Runtime.InteropServices;
using System.IO;
using System.Net.Mail;
using System.Net;
using Microsoft.Win32;
using System.Diagnostics;
using System.Threading;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace ExplodingKittens
{
    public partial class Form2 : Form
    {
        Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        byte[] MsgFromServer = new byte[1024];

        string[] ReceivedCard;
        List<PictureBox> Hand = new List<PictureBox>();
        List<PictureBox> selected = new List<PictureBox>();

        string PName = "";

        int numplayed = 0;
        string imageforplayed = "";
        bool turn = false;
        bool update_hand = false;
        PictureBox ToBeRemoved = null;
        string[] info = new string[4];
        string[] infogive = new string[3];
        bool favored = false;
        bool needdefuse = false;
        List<string> AllPNameOrdered = new List<string>();
        List<string> AllAlivePName = new List<string>();

        bool CanNope = false;

        string received(byte[] msg)
        {
            msg = new byte[1024];
            int size = ClientSocket.Receive(msg);
            return Encoding.ASCII.GetString(msg, 0, size);
        }

        public Form2(Socket Client, string Player1)
        {
            InitializeComponent();
            ClientSocket = Client;
            PName = Player1;

            //Receiving Dealt Cards
            ReceivedCard = received(MsgFromServer).Split(' ');
            foreach (string card in ReceivedCard)
            {
                if (card != "")
                {
                    PictureBox box = new PictureBox();
                    SetPb(box, card);
                    Hand.Add(box);
                }
            }
            ShowCards();
            Send("READY");

            //Displaying names of all players
            string[] rearranged = new string[4];
            string[] AllPNames = received(MsgFromServer).Split(' ');
            int position = 0;
            for (int i = 0; i < 4; i++)
            {
                if (AllPNames[i] == PName)
                {
                    position = i;
                    break;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (i + position >= 4)
                {
                    rearranged[i] = AllPNames[i + position - 4];
                }
                else
                {
                    rearranged[i] = AllPNames[i + position];
                }
            }
            foreach (string name in rearranged)
            {
                AllPNameOrdered.Add(name);
                AllAlivePName.Add(name);
            }
            P1.Text = rearranged[0];
            P2.Text = rearranged[1];
            P3.Text = rearranged[2];
            P4.Text = rearranged[3];
            Send("READY1");

            Thread Check = new Thread(new ThreadStart(Updates));
            Check.Start();
            timer1.Start();
        }

        //Game officially starts -----------------------------------------------------------------------------
        private void Updates()
        {
            while (true)
            {
                string got = received(MsgFromServer);
                string[] playedcards = got.Split(' ');

                if (got == " TURN")
                {
                    turn = true;
                }
                else if (playedcards[0] == "END")
                {
                    info = playedcards;
                }
                else if (playedcards[0] == "BOMB")
                {
                    info = playedcards;
                }

                else if (playedcards[0] == "DEAD")
                {
                    info = playedcards;
                }
                //Server giving cards to player
                else if (playedcards[0] == "DRAW")
                {
                    PictureBox box = new PictureBox();
                    SetPb(box, playedcards[1]);
                    Hand.Add(box);
                    update_hand = true;
                }

                //Showing the cards other player played
                else if (playedcards[0] == "PLAYED")
                {
                    numplayed = Int32.Parse(playedcards[2]);
                    imageforplayed = playedcards[1];

                    Thread.Sleep(500);

                    if (playedcards.Count() > 3)
                    { 
                        if (playedcards[3] == "NOPETIMEOVER")
                        {
                            CanNope = false;
                            if (playedcards.Count() > 4)
                            {
                                if (playedcards[4] == "GIVE")
                                {
                                    List<string> dummy = new List<string>();
                                    for (int i = 4; i < playedcards.Length; i++)
                                    {
                                        dummy.Add(playedcards[i]);
                                    }
                                    playedcards = dummy.ToArray();
                                }
                            }
                        }
                        else
                        {
                            CanNope = true;
                            if (playedcards.Count() >= 6)
                            {
                                if (playedcards[4] == "SHOWARROW" || playedcards[5] == "SHOWARROW") 
                                {
                                    string[] dummy = {"GIVE", "SD", playedcards[playedcards.Length - 1] };
                                    infogive = dummy;
                                }
                            }
                        }
                    }
                    else
                    {
                        CanNope = true;
                    }
                    int inhand = Hand.Count;
                    Thread.Sleep(4000);
                    int newinhand = Hand.Count;

                    if (inhand == newinhand)
                    {
                        Send("DIDNOTPLAYNOPE");
                    }
                }

                if (playedcards[0] == "GIVE")
                {
                    if (Hand.Count() > 0)
                    {
                        infogive = playedcards;
                        if (playedcards[2] == PName)
                        {
                            if (playedcards[1] == "RANDOM")
                            {
                                Random rnd = new Random();
                                int ind = rnd.Next(0, Hand.Count);
                                Send(Hand[ind].Name);

                                ToBeRemoved = Hand[ind];
                            }
                            else if (playedcards[1] == "CHOOSE")
                            {
                                favored = true;
                            }
                            else
                            {
                                bool havecard = false;
                                for (int i = 0; i < Hand.Count; i++)
                                {
                                    if (Hand[i].Name == playedcards[1])
                                    {
                                        havecard = true;
                                        Send(playedcards[1]);
                                        ToBeRemoved = Hand[i];
                                        break;
                                    }
                                }
                                if (havecard == false)
                                {
                                    Send("NOTHAVE");
                                }
                            }
                        }
                    }
                    else
                    {
                        Send("NOTHAVE");
                    }
                }
                else if (playedcards[0] == "SEE")
                {
                    Form4 form4 = new Form4(playedcards[1], playedcards[2], playedcards[3]);
                    form4.ShowDialog();
                }
                else if (playedcards[0] == "NOPETIMEOVER")
                {
                    CanNope = false;

                }
            }
        }


        private void Send(string message)
        {
            ClientSocket.Send(Encoding.ASCII.GetBytes(message), 0, message.Length, SocketFlags.None);
        }

        private void Picture_Click(object sender, EventArgs e)
        {
            //Add selected image to selected pictureboxes

            if (selected.Contains((PictureBox)sender) == false)
            {
                selected.Add((PictureBox)sender);
                Control ctn = (Control)sender;
                int y = ctn.Location.Y;
                y -= 75;
                ctn.Location = new Point(ctn.Location.X, y);
            }
            else
            {
                selected.Remove((PictureBox)sender);
                Control ctn = (Control)sender;
                int y = ctn.Location.Y;
                y += 75;
                ctn.Location = new Point(ctn.Location.X, y);
            }

        }

        private void ShowCards()
        {
            int position = 100;
            foreach (PictureBox pb in Hand)
            {
                pb.Location = new Point(position, 400);
                position += 100;

                this.Controls.Add(pb);
            }
        }

        private void Play_Click(object sender, EventArgs e)
        {
            if (selected.Count != 0)
            {
                //Determine if the selected hand is a valid play
                bool valid = false;
                if (turn == true && CanNope == false)
                {
                    if (selected.Count == 2)
                    {
                        if (selected[0].Name == selected[1].Name)
                        {
                            P2.Enabled = true;
                            P3.Enabled = true;
                            P4.Enabled = true;
                        }
                    }
                    else if (selected.Count == 3)
                    {
                        if (selected[0].Name == selected[1].Name && selected[0].Name == selected[2].Name)
                        {
                            P2.Enabled = true;
                            P3.Enabled = true;
                            P4.Enabled = true;
                        }
                    }
                    else if (selected.Count == 5)
                    {
                        bool notequal = true;
                        for (int i = 0; i < selected.Count; i++)
                        {
                            for (int j = i + 1; j < selected.Count; j++)
                            {
                                if (selected[i] == selected[j])
                                {
                                    notequal = false;
                                }
                            }
                        }
                        if (notequal)
                        {
                            P2.Enabled = true;
                            P3.Enabled = true;
                            P4.Enabled = true;
                        }
                    }
                    else if (selected.Count == 1)
                    {
                        if (selected[0].Name == "ATTACK" || selected[0].Name == "SEE_THE_FUTURE" || selected[0].Name == "SHUFFLE" || selected[0].Name == "SKIP")
                        {
                            valid = true;
                        }
                        if (selected[0].Name == "FAVOR")
                        {
                            P2.Enabled = true;
                            P3.Enabled = true;
                            P4.Enabled = true;
                        }
                    }
                }
                if (needdefuse == true)
                {
                    if (selected.Count == 1 && selected[0].Name == "DEFUSE")
                    {
                       valid = true;
                    }
                }
                

                if (CanNope == true && selected.Count == 1 && selected[0].Name == "NOPE")
                {
                    valid = true;
                }
                //Give the server the selected cards
                if (valid)
                {
                    if (selected[0].Name == "SKIP" || selected[0].Name == "ATTACK" && selected.Count == 1)
                    {
                        int temp = Hand.Count + 1;
                        Send("PLAYED " + selected[0].Name + " " + selected.Count.ToString() + " " + PName + " " + temp.ToString());
                    }
                    else if (selected[0].Name == "DEFUSE" && selected.Count == 1)
                    {
                        string position = "";
                        using (Form5 form5 = new Form5())
                        {
                            if (form5.ShowDialog() == DialogResult.OK)
                            {
                                position = form5.position;
                            }
                        }
                        Send("DEFUSE " + position);
                        needdefuse = false;
                    }
                    else
                    {
                        Send("PLAYED " + selected[0].Name + " " + selected.Count.ToString());
                    }
                    
                    foreach (PictureBox pb in selected)
                    {
                        Hand.Remove(pb);

                        pb.Click -= Picture_Click;
                        this.Controls.Remove(pb);
                        pb.Dispose();
                    }

                    selected.Clear();
                    ShowCards();
                }
            }
        }

        private void EndTurn_Click(object sender, EventArgs e)
        {
            turn = false;
            EndTurn.Enabled = false;
            int temp = Hand.Count + 1;
            Send("END " + PName + " " + temp.ToString());
        }

        private void SetPb(PictureBox pb, string name)
        {
            pb.Width = 165;
            pb.Height = 240;
            pb.BorderStyle = BorderStyle.Fixed3D;
            switch (name)
            {
                case "DEFUSE":
                    pb.Image = Properties.Resources.DEFUSE;
                    break;
                case "ATTACK":
                    pb.Image = Properties.Resources.ATTACK;
                    break;
                case "BEARD_CAT":
                    pb.Image = Properties.Resources.BEARD_CAT;
                    break;
                case "BOMB":
                    pb.Image = Properties.Resources.BOMB;
                    break;
                case "CATTERMELON":
                    pb.Image = Properties.Resources.CATTERMELON;
                    break;
                case "FAVOR":
                    pb.Image = Properties.Resources.FAVOR;
                    break;
                case "HAIRY_POTATO_CAT":
                    pb.Image = Properties.Resources.HAIRY_POTATO_CAT;
                    break;
                case "NOPE":
                    pb.Image = Properties.Resources.NOPE;
                    break;
                case "RAINBOW":
                    pb.Image = Properties.Resources.RAINBOW;
                    break;
                case "SEE_THE_FUTURE":
                    pb.Image = Properties.Resources.SEE_THE_FUTURE;
                    break;
                case "SHUFFLE":
                    pb.Image = Properties.Resources.SHUFFLE;
                    break;
                case "SKIP":
                    pb.Image = Properties.Resources.SKIP;
                    break;
                case "TACOCAT":
                    pb.Image = Properties.Resources.TACOCAT;
                    break;
            }
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Name = name;
            pb.Click += Picture_Click;
            pb.Anchor = AnchorStyles.Bottom;
        }

        //Cannot update UI through another thread, so this is the only way around it
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (favored)
            {
                Give.Enabled = true;
                favored = false;
            }
            if (info[0] == "END")
            {
                int pos = AllPNameOrdered.IndexOf(info[1]);
                if (pos == 0)
                {
                    P1.Font = new Font(P1.Font.Name, P1.Font.Size, FontStyle.Regular);
                    turn = false;
                }
                else if (pos == 1)
                {
                    P2.Font = new Font(P2.Font.Name, P2.Font.Size, FontStyle.Regular);
                    P2CardNum.Text = info[2].ToString();
                }
                else if (pos == 2)
                {
                    P3.Font = new Font(P3.Font.Name, P3.Font.Size, FontStyle.Regular);
                    P3CardNum.Text = info[2].ToString();
                }
                else if (pos == 3)
                {
                    P4.Font = new Font(P4.Font.Name, P4.Font.Size, FontStyle.Regular);
                    P4CardNum.Text = info[2].ToString();
                }

                while (true)
                {
                    pos++;
                    if (pos == 4)
                    {
                        pos = 0;
                    }
                    int alive = AllAlivePName.IndexOf(AllPNameOrdered[pos]);
                    if (alive != -1)
                    {
                        if (pos == 0)
                        {
                            P1.Font = new Font(P1.Font.Name, P1.Font.Size, FontStyle.Underline);
                        }
                        else if (pos == 1)
                        {
                            P2.Font = new Font(P2.Font.Name, P2.Font.Size, FontStyle.Underline);
                        }
                        else if (pos == 2)
                        {
                            P3.Font = new Font(P3.Font.Name, P3.Font.Size, FontStyle.Underline);
                        }
                        else if (pos == 3)
                        {
                            P4.Font = new Font(P4.Font.Name, P4.Font.Size, FontStyle.Underline);
                        }
                        break;
                    }
                }
                CanNope = false;
                P1Bomb.Visible = false;
                P2Bomb.Visible = false;
                P3Bomb.Visible = false;
                P4Bomb.Visible = false;
                DeckCardCount.Text = "Number of cards left in the deck: " + info[3];
                info = new string[4];
            }
            else if (info[0] == "BOMB")
            {
                if (info[1] == PName)
                {
                    P1Bomb.Visible = true;
                    needdefuse = true;
                    bool havecard = false;
                    for (int i = 0; i < Hand.Count; i++)
                    {
                        if (Hand[i].Name == "DEFUSE")
                        {
                            havecard = true;
                        }
                    }
                    if (havecard == false)
                    {
                        Send("NODEFUSE");
                    }
                }
                else if (info[1] == P2.Text)
                {
                    P2Bomb.Visible = true;
                }
                else if (info[1] == P3.Text)
                {
                    P3Bomb.Visible = true;
                }
                else
                {
                    P4Bomb.Visible = true;
                }
                info = new string[4];
            }
            else if (info[0] == "DEAD")
            {
                int pos = AllPNameOrdered.IndexOf(info[1]);
                AllAlivePName.Remove(info[1]);

                if (pos == 0)
                {
                    P1DEAD.Visible = true;
                }
                else if (pos == 1)
                {
                    P2DEAD.Visible = true;
                }
                else if (pos == 2)
                {
                    P3DEAD.Visible = true;
                }
                else if (pos == 3)
                {
                    P4DEAD.Visible = true;
                }
                info = new string[4];
            }

            if (infogive[0] == "GIVE")
            {
                if (infogive[2] == PName)
                {
                    DOWN.Visible = true;
                    timer2.Start();
                }
                if (infogive[2] == P2.Text)
                {
                    LEFT.Visible = true;
                    timer2.Start();
                }
                if (infogive[2] == P3.Text)
                {
                    UP.Visible = true;
                    timer2.Start();
                }
                if (infogive[2] == P4.Text)
                {
                    RIGHT.Visible = true;
                    timer2.Start();
                }
            }
            if (ToBeRemoved != null)
            {
                Hand.Remove(ToBeRemoved);

                ToBeRemoved.Click -= Picture_Click;
                this.Controls.Remove(ToBeRemoved);
                ToBeRemoved.Dispose();
                ShowCards();
                ToBeRemoved = null;
            }
            if (update_hand)
            {
                ShowCards();
                update_hand = false;
            }
            if (imageforplayed != "")
            {
                switch (imageforplayed)
                {
                    case "DEFUSE":
                        PlayedCard.Image = Properties.Resources.DEFUSE;
                        break;
                    case "ATTACK":
                        PlayedCard.Image = Properties.Resources.ATTACK;
                        break;
                    case "BEARD_CAT":
                        PlayedCard.Image = Properties.Resources.BEARD_CAT;
                        break;
                    case "BOMB":
                        PlayedCard.Image = Properties.Resources.BOMB;
                        break;
                    case "CATTERMELON":
                        PlayedCard.Image = Properties.Resources.CATTERMELON;
                        break;
                    case "FAVOR":
                        PlayedCard.Image = Properties.Resources.FAVOR;
                        break;
                    case "HAIRY_POTATO_CAT":
                        PlayedCard.Image = Properties.Resources.HAIRY_POTATO_CAT;
                        break;
                    case "NOPE":
                        PlayedCard.Image = Properties.Resources.NOPE;
                        break;
                    case "RAINBOW":
                        PlayedCard.Image = Properties.Resources.RAINBOW;
                        break;
                    case "SEE_THE_FUTURE":
                        PlayedCard.Image = Properties.Resources.SEE_THE_FUTURE;
                        break;
                    case "SHUFFLE":
                        PlayedCard.Image = Properties.Resources.SHUFFLE;
                        break;
                    case "SKIP":
                        PlayedCard.Image = Properties.Resources.SKIP;
                        break;
                    case "TACOCAT":
                        PlayedCard.Image = Properties.Resources.TACOCAT;
                        break;
                }
                NumofPlayed.Text = numplayed.ToString() + "x";
            }
            if (turn && CanNope == false)
            {
                EndTurn.Enabled = true;
            }
            if (turn == false || CanNope == true)
            {
                EndTurn.Enabled = false;
            }
        }

        private void ChoosePlayer(object sender, EventArgs e)
        {
            if (selected.Count == 2 && selected[0].Name == selected[1].Name || selected.Count == 1 && selected[0].Name == "FAVOR")
            {
                string chosen = (sender as Button).Text;
                Send("PLAYED " + selected[0].Name + " " + selected.Count.ToString() + " " + chosen);
                foreach (PictureBox pb in selected)
                {
                    Hand.Remove(pb);

                    pb.Click -= Picture_Click;
                    this.Controls.Remove(pb);
                    pb.Dispose();
                }

                selected.Clear();
                ShowCards();
                P2.Enabled = false;
                P3.Enabled = false;
                P4.Enabled = false;

            }
            if (selected.Count == 3 || selected.Count == 5)
            {
                bool notequal = true;
                for (int i = 0; i < selected.Count; i++)
                {
                    for (int j = i + 1; j < selected.Count; j++)
                    {
                        if (selected[i] == selected[j])
                        {
                            notequal = false;
                        }
                    }
                }
                if (selected[0].Name == selected[1].Name && selected[0].Name == selected[2].Name && selected.Count == 3 || selected.Count == 5 && notequal)
                {
                string chosen = (sender as Button).Text;
                string selectedType = "";
                using (Form3 form3 = new Form3())
                {
                    if (form3.ShowDialog() == DialogResult.OK)
                    {
                        selectedType = form3.selectedtype;
                    }
                }
                Send("PLAYED " + selected[0].Name + " " + selected.Count.ToString() + " " + chosen + " " + selectedType);

                foreach (PictureBox pb in selected)
                {
                    Hand.Remove(pb);

                    pb.Click -= Picture_Click;
                    this.Controls.Remove(pb);
                    pb.Dispose();
                }

                selected.Clear();
                ShowCards();
                P2.Enabled = false;
                P3.Enabled = false;
                P4.Enabled = false;
                }
            }

            //Selected is not a valid play when choosing player
            else
            {
                P2.Enabled = false;
                P3.Enabled = false;
                P4.Enabled = false;
            }
        }

        private void Give_Click(object sender, EventArgs e)
        {
            if (selected.Count == 1)
            {
                Send(selected[0].Name);
                Hand.Remove(selected[0]);

                selected[0].Click -= Picture_Click;
                this.Controls.Remove(selected[0]);
                selected[0].Dispose();

                selected.Clear();
                ShowCards();
                Give.Enabled = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            DOWN.Visible = false;
            LEFT.Visible = false;
            UP.Visible = false;
            RIGHT.Visible = false;
            infogive = new string[3];
            ((System.Windows.Forms.Timer)sender).Stop();
        }
    }
}
