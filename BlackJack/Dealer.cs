using System.Collections.Generic;
using TDDBlackJack;

namespace BlackJackTest
{
    public class Dealer : Player
    {
        public Dealer(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

        public void Play(Deck gameDeck)
        {
            if (!this.HasBlackJack() && !this.IsBusted() && Hand.GetTotal() < 17)
            {
                gameDeck.Draw(this);
            }
        }

    }

}
