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
    public partial class Form1 : Form
    {
        static string publicIP = "162.156.115.88";
        static string privateIP = "127.0.0.1";
        Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse(privateIP), 5004);

        public Form1()
        {
            InitializeComponent();
            
        }
        
        private void init_Click(object sender, EventArgs e)
        {
            if (NName.Text != "" && !NName.Text.Contains(" "))
            {
                Connect();
            }
        }

        private void Connect()
        {
            init.Enabled = false;
            info.Text = "Waiting for players";
            ClientSocket.Connect(ep);
            Send(NName.Text);
            Thread Check = new Thread(new ThreadStart(Getinfo));
            Check.Start();  
        }

        private void Send(string message)
        {
            ClientSocket.Send(Encoding.ASCII.GetBytes(message), 0, message.Length, SocketFlags.None);
        }

        private void Getinfo()
        {
            try
            {
                byte[] MsgFromServer = new byte[1024];
                int size = ClientSocket.Receive(MsgFromServer);
                string message = Encoding.ASCII.GetString(MsgFromServer, 0, size);
                if (message == "Start")
                {
                    //Open a new form and make game start
                    Application.Run(new Form2(ClientSocket, NName.Text));
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
        }
    }
}
