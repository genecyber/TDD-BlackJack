using System;
using System.Collections.Generic;

namespace TDDBlackJack
{
    public class Card
    {
        public Card()
        {
            var r1 = new Random();
            var r2 = new Random();
            Suit = Suits()[r1.Next(0, 4)];
            Value = Values()[r2.Next(0, 13)];
        }
        public Card(string suitToCreate, int valueToCreate)
        {
            if (valueToCreate > 13)
                throw new Exception("Cannot create cards of value higher then 13");
            Suit = suitToCreate;
            Value = Values()[valueToCreate - 1];
        }
        public string Suit { get; set; }
        public CardValue Value { get; set; }

        public List<string> Suits()
        {
            var suits = new List<string> {"Spade", "Heart", "Diamond", "Club"};
            return suits;
        }

        public List<CardValue> Values()
        {
            var values = new List<CardValue>
                             {
                                 new CardValue("Ace", 1,11),
                                 new CardValue("Two", 2,2),
                                 new CardValue("Three", 3,3),
                                 new CardValue("Four", 4,4),
                                 new CardValue("Five", 5,5),
                                 new CardValue("Six", 6,6),
                                 new CardValue("Seven", 7,7),
                                 new CardValue("Eight", 8,8),
                                 new CardValue("Nine", 9,9),
                                 new CardValue("Ten", 10,10),
                                 new CardValue("Jack", 11,10),
                                 new CardValue("Queen", 12,10),
                                 new CardValue("King", 13,10)
                             };
            return values;
        }
    }
    public class CardValue
    {
        public CardValue(string name, int value, int faceValue)
        {
            Name = name;
            Value = value;
            FaceValue = faceValue;

        }
        public string Name { get; set; }
        public int Value { get; set; }
        public int FaceValue { get; set; }
    }
}
