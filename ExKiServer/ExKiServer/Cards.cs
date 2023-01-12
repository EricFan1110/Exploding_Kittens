using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExKiServer
{
    public class Cards
    {
        public string Type { get; set; }

        public Cards(string type)
        {
            this.Type = type;
        }
    }

    public class Deck
    {
        private Stack<Cards> _deck = new Stack<Cards>();

        private Random _rnd = new Random();

        private readonly string[] _type1 = {"CATTERMELON", "BEARD_CAT", "HAIRY_POTATO_CAT", "TACOCAT", "RAINBOW", 
                                              "ATTACK", "SHUFFLE", "FAVOR", "SKIP", "SEE_THE_FUTURE", "NOPE" };

        private readonly string[] _type2 = { "BOMB", "DEFUSE" };

        //Initialize the deck without inserting BOMB and DEFUSE
        public void BuildDeck()
        {
            foreach (string type in this._type1)
            {
                if (type == "SEE_THE_FUTURE" || type == "NOPE")
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Cards card = new Cards(type);
                        this._deck.Push(card);
                    }
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Cards card = new Cards(type);
                        this._deck.Push(card);
                    }
                }
            }
        }

        //Shuffle the deck
        public void Shuffle()
        {
            this._deck = new Stack<Cards>(this._deck.OrderBy(x => this._rnd.Next()));
        }

        //Give each player 5 cards at the beginning of the game
        public Stack<Cards> DealHand()
        {
            Stack<Cards> hand = new Stack<Cards>();
            
            for (int i = 0; i < 4; i++)
            {
                hand.Push(this._deck.Pop());
            }

            Cards defusecard = new Cards("DEFUSE");
            hand.Push(defusecard);

            return hand;
        }

        //Rebuild the deck after dealing the cards to the player by inserting BOMB and DEFUSE.
        public void SecondBuild()
        {
            foreach (string type in this._type2)
            {
                if (type == "DEFUSE")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Cards card = new Cards(type);
                        this._deck.Push(card);
                    }
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Cards card = new Cards(type);
                        this._deck.Push(card);
                    }
                }
            }
        }

        //Return the top card of the deck
        public Cards Draw()
        {
            return this._deck.Pop();
        }

        //Return the card to the top of the deck
        public void Push(Cards card)
        {
            this._deck.Push(card);
        }

        //Return number of cards in the deck
        public int Count()
        {
            return this._deck.Count();
        }

        //Return the card to the specified position in the deck
        public void Insert(Cards card, int pos)
        {
            Stack<Cards> temp = new Stack<Cards>();
            for (int i = 0; i < pos; i++)
            {
                temp.Push(this._deck.Pop());
            }
            this._deck.Push(card);
            for (int i = 0; i < pos; i++)
            {
                this._deck.Push(temp.Pop());
            }
        }
    }
}
