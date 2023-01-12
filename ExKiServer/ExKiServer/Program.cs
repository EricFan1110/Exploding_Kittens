using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Diagnostics;

namespace ExKiServer
{
    class Program
    {
        static int numplayerinroom = 4;

        static void Main(string[] args)
        {
            int counter = 0;
            Socket ServerListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 5004);


            ServerListener.Bind(ep);
            ServerListener.Listen(100);
            Socket ClientSocket = default(Socket);

            List<Socket> playersWaiting = new List<Socket>();
            List<Socket> playersInGame = new List<Socket>();
            List<string> namesplaying = new List<string>();
            List<string> nameswaiting = new List<string>();

            Program p = new Program();
            bool gameinsession = false;

            while (true)
            {
                byte[] msg = new byte[1024];

                //Connect to client
                ClientSocket = ServerListener.Accept();

                //Add players and names to list
                playersWaiting.Add(ClientSocket);
                int size = ClientSocket.Receive(msg);
                nameswaiting.Add(Encoding.ASCII.GetString(msg, 0, size));

                counter++;
                Console.WriteLine(counter + " clients connected ");

                if (playersWaiting.Count >= numplayerinroom && gameinsession == false)
                {
                    //Players ready
                    Console.WriteLine("Players ready");
                    gameinsession = true;

                    for (int i = 0; i < numplayerinroom; i++)
                    {
                        playersInGame.Add(playersWaiting[0]);
                        playersWaiting.RemoveAt(0);
                        namesplaying.Add(nameswaiting[0]);
                        nameswaiting.RemoveAt(0);
                    }

                    foreach (Socket player in playersInGame)
                    {
                        Send(player, "Start");
                    }

                    Thread Game = new Thread(new ThreadStart(() => p.Room(playersInGame, namesplaying)));
                    Game.Start();
                }

            }
        }

        public void Room(List<Socket> player, List<string> names)
        {
            //Initialize Game
            Console.WriteLine("Game Start");

            Deck deck = new Deck();
            deck.BuildDeck();
            deck.Shuffle();
            Stack<Cards> Hand = new Stack<Cards>();
            string sendinfo = "";
            bool attack = false;
            bool skip = false;
            int alive = numplayerinroom;

            //Deal Hand
            foreach (Socket Player in player)
            {
                Hand = deck.DealHand();
                foreach (Cards card in Hand)
                {
                    sendinfo = sendinfo + card.Type + " ";
                }
                Send(Player, sendinfo);
                sendinfo = "";
            }
            deck.SecondBuild();
            deck.Shuffle();

            while (true)
            {
                int ready = 0;
                foreach (Socket Player in player)
                {
                    if (receive(Player) == "READY")
                    {
                        ready += 1;
                    }
                }
                if (ready == numplayerinroom)
                {
                    break;
                }
            }

            //Setting up names
            string pname = "";
            foreach (string Name in names)
            {
                pname = pname + Name + " ";
            }

            foreach (Socket Player in player)
            {
                Send(Player, pname);
            }

            while (true)
            {
                int ready = 0;
                foreach (Socket Player in player)
                {
                    if (receive(Player) == "READY1")
                    {
                        ready += 1;
                    }
                }
                if (ready == numplayerinroom)
                {
                    break;
                }
            }

            Console.WriteLine("Initiallized");

            //----------------------Game start------------------------------
            while (true)
            {
                string[] temp = new string[5];
                for (int i = 0; i < alive; i++)
                {
                    Send(player[i], " TURN");
                    while (true)
                    {
                        string send = receive(player[i]);
                        string[] receivedToArray = send.Split(' ');
                        Console.WriteLine(send);

                        //A player has ended their turn, and a card is drawn
                        if (receivedToArray[0] == "END")
                        {
                            Cards drawn = deck.Draw();
                            if (drawn.Type == "BOMB")
                            {
                                string send1 = "1 2";
                                string[] send1coded = send1.Split(' ');
                                UpdateAll(player, "BOMB " + names[i]);
                                while (send1coded[0] != "DEFUSE" && send1 != "NODEFUSE")
                                {
                                    send1 = receive(player[i]);
                                    send1coded = send1.Split(' ');
                                }

                                if (send1coded[0] == "DEFUSE")
                                {
                                    //Defuse played, insert the bomb back into the deck
                                    switch (send1coded[1])
                                    {
                                        case "Top":
                                            deck.Insert(drawn, 0);
                                            break;
                                        case "Second":
                                            deck.Insert(drawn, 1);
                                            break;
                                        case "3rd":
                                            if (deck.Count() > 2)
                                                deck.Insert(drawn, 2);
                                            else
                                                deck.Insert(drawn, deck.Count());
                                            break;
                                        case "4th":
                                            if (deck.Count() > 3)
                                                deck.Insert(drawn, 3);
                                            else
                                                deck.Insert(drawn, deck.Count());
                                            break;
                                        case "5th":
                                            if (deck.Count() > 4)
                                                deck.Insert(drawn, 4);
                                            else
                                                deck.Insert(drawn, deck.Count());
                                            break;
                                        case "Last":
                                            deck.Insert(drawn, deck.Count());
                                            break;
                                        case "Random":
                                            int x = 0;
                                            Random rnd = new Random();
                                            x = rnd.Next(0, deck.Count());
                                            deck.Insert(drawn, x);
                                            break;
                                    }
                                }
                                else if (send1 == "NODEFUSE")
                                {
                                    //Player drew a bomb but does not have defuse, theirfore remove player
                                    UpdateAll(player, "DEAD " + names[i]);
                                    names.Remove(names[i]);
                                    player.Remove(player[i]);
                                    alive--;
                                    i--;
                                    break;
                                }
                            }
                            else
                            {
                                Send(player[i], "DRAW " + drawn.Type);
                            }

                            if (attack)
                            {
                                i--;
                                attack = false;
                                break;
                            }
                            else
                            {
                                UpdateAll(player, "END " + receivedToArray[1] + " " + receivedToArray[2] + " " + deck.Count().ToString());
                                break;
                            }
                        }

                        //Player has played cards
                        else if (receivedToArray[0] == "PLAYED")
                        {
                            if (receivedToArray.Count() > 3)
                            {
                                if (names.IndexOf(receivedToArray[3]) > -1)
                                {
                                    UpdateAll(player, send + " SHOWARROW " + receivedToArray[3]);
                                    Console.WriteLine(send + " SHOWARROW " + receivedToArray[3]);
                                }
                            }
                            else
                            {
                                UpdateAll(player, send);
                                Console.WriteLine(send);
                            }
                            
                            bool noped = false;
                            bool loop = false;
                            int nopeplayed = 0;

                            //Detect whether a NOPE card is played in the allowed time
                            do
                            {
                                Thread.Sleep(4000);
                                foreach (Socket p in player)
                                {
                                    string[] split = receive(p).Split(' ');

                                    if (split[0] == "PLAYED")
                                    {
                                        if (split[1] == "NOPE")
                                        {
                                            if (noped == false)
                                            {
                                                noped = true;
                                            }
                                            else
                                            {
                                                noped = false;
                                            }
                                            loop = true;
                                            nopeplayed++;
                                        }
                                    }
                                }
                                if (nopeplayed > 0)
                                    UpdateAll(player, "PLAYED NOPE " + nopeplayed + ' ');
                                loop = false;
                            } while (loop);

                            Console.WriteLine(nopeplayed);

                            UpdateAll(player, "NOPETIMEOVER ");

                            //Pair has been played
                            if (noped == false)
                            {
                                if (receivedToArray[2] == "2")
                                {
                                    int index = names.IndexOf(receivedToArray[3]);
                                    UpdateAll(player, "GIVE RANDOM " + names[index] + ' ');
                                    string gotcard = "";
                                    while (gotcard == "")
                                    {
                                        gotcard = receive(player[index]);
                                    }
                                    if (gotcard != "NOTHAVE")
                                    {
                                        Send(player[i], "DRAW " + gotcard);
                                    }
                                }
                                //Triple has been played
                                else if (receivedToArray[2] == "3" || receivedToArray[2] == "5")
                                {
                                    int index = names.IndexOf(receivedToArray[3]);
                                    UpdateAll(player, "GIVE " + receivedToArray[4] + " " + names[index] + ' ');
                                    string gotcard = "";
                                    while (gotcard == "")
                                    {
                                        gotcard = receive(player[index]);
                                    }
                                    if (gotcard != "NOTHAVE")
                                    {
                                        Send(player[i], "DRAW " + gotcard);
                                    }
                                }
                                //Single cards has been played
                                else
                                {
                                    if (receivedToArray[1] == "FAVOR")
                                    {
                                        int index = names.IndexOf(receivedToArray[3]);
                                        UpdateAll(player, "GIVE CHOOSE " + names[index] + ' ');
                                        string gotcard = "";
                                        while (gotcard == "")
                                        {
                                            gotcard = receive(player[index]);
                                        }
                                        if (gotcard != "NOTHAVE")
                                        {
                                            Send(player[i], "DRAW " + gotcard);
                                        }

                                    }
                                    else if (receivedToArray[1] == "SEE_THE_FUTURE")
                                    {
                                        Cards first = deck.Draw();
                                        Cards second = deck.Draw();
                                        Cards third = deck.Draw();

                                        Send(player[i], "SEE " + first.Type + " " + second.Type + " " + third.Type);

                                        deck.Push(third);
                                        deck.Push(second);
                                        deck.Push(first);
                                    }

                                    else if (receivedToArray[1] == "SHUFFLE")
                                    {
                                        deck.Shuffle();
                                    }

                                    else if (receivedToArray[1] == "SKIP")
                                    {
                                        skip = true;
                                        temp = receivedToArray;
                                        break;
                                    }

                                    else if (receivedToArray[1] == "ATTACK")
                                    {
                                        UpdateAll(player, "END " + receivedToArray[3] + " " + receivedToArray[4] + " " + deck.Count().ToString());
                                        attack = true;
                                        break;
                                    }

                                }
                            }
                        }
                    }
                    if (skip && attack)
                    {
                        i--;
                        skip = false;
                        attack = false;
                        continue;
                    }
                    if (skip)
                    {
                        UpdateAll(player, "END " + temp[3] + " " + temp[4] + " " + deck.Count().ToString());
                        skip = false;
                    }
                }
            }
        }

        //Send specific instruction to a certain player
        static private void Send(Socket client, string message)
        {
            client.Send(Encoding.ASCII.GetBytes(message), 0, message.Length, SocketFlags.None);
        }

        //Send specific instruction to all player
        static private void UpdateAll(List<Socket> client, string message)
        {
            foreach (Socket c in client)
            {
                Send(c, message);
            }
        }

        //Receive player action from a specific player
        static private string receive(Socket client)
        {
            byte[] msg = new byte[1024];
            int size = client.Receive(msg);
            return Encoding.ASCII.GetString(msg, 0, size);
        }
    }
}
