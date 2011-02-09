using System;
using System.Collections.Generic;

namespace TDDBlackJack
{
    public class Deck
    {
        public Deck()
        {
            CreateDeck();
            Shuffle();
        }

        private void CreateDeck()
        {
            var card = new Card();
            foreach (var suit in  card.Suits())
            {
                foreach (var value in card.Values())
                {
                    var cardToAdd = new Card(suit, value.Value);
                    CardsRemaining.Add(cardToAdd);
                }
            }

        }
        public void Shuffle()
        {
            CardsRemaining = ShuffleDeck(CardsRemaining);
        }

        private static List<T> ShuffleDeck<T>(IList<T> inputList)
        {
            var randomList = new List<T>();

            var r = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0));
            while (inputList.Count > 0)
            {
                var randomIndex = r.Next(0, inputList.Count);
                randomList.Add(inputList[randomIndex]); 
                inputList.RemoveAt(randomIndex);
            }
            return randomList; 
        }

        public List<Card> CardsRemaining = new List<Card>();

        public Card Draw(int toDraw = 1)
        {
            if (toDraw < 0)
            {
                throw new Exception("Cannot Deal Negative");
            }
            if (toDraw > 1)
            {
                throw new Exception("Cannot Deal More Then 1 Cards");
            }
            Card remove = CardsRemaining[0];
            CardsRemaining.Remove(remove);
            return remove;
        }
        public void Draw(Player player, int toDraw = 1)
        {
            var card = Draw(toDraw);
            player.Hand.Add(new Player.LiveCard(card,false));
        }
        private Card Draw(Card toDraw)
        {
            var toRemove = CardsRemaining.Find(f => f.Suit == toDraw.Suit & f.Value.Value == toDraw.Value.Value);
            if (toRemove == null)
            {
                throw new Exception("Cannot draw the same card twice");
            }
            CardsRemaining.Remove(toRemove);
            return toRemove;
        }
    }
}
