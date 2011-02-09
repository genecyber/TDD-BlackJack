using System;
using System.Collections.Generic;

namespace TDDBlackJack
{
    public class Player
    {
        public Player()
        {
            Hand = new List<LiveCard>();
            Stayed = false;
        }
        public Player(string name) : this()
        {
            Name = name;
            Bank = 0.0;
        }
        public Player(string name, double bank) : this()
        {
            Name = name;
            Bank = bank;
        }
        public string Name { get; set; }
        public double Bank { get; set; }

        public bool Stayed
        {
            get;
            set;
        }
        public bool HasStayed
        {
            get
            {
                if (Stayed || this.HasBlackJack())
                    return true;
                return false;
            }
        }

        public List<LiveCard> Hand { get; set; }

        public class LiveCard
        {
            public LiveCard(Card card)
            {
                Card = card;
                FaceUp = false;
            }
            public LiveCard(Card card, bool faceUp)
            {
                Card = card;
                FaceUp = faceUp;
            }

            public LiveCard()
            {
                
            }

            public Card Card { get; set; }
            public bool FaceUp { get; set; }
        }
    }
}
