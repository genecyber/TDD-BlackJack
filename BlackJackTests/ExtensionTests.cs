using System.Collections.Generic;
using BlackJackTest;
using NUnit.Framework;
using TDDBlackJack;
using FluentAssertions;

namespace BlackJack
{
    [TestFixture]
    public class ExtensionTests
    {
        [Test]
        public void HasBlackJack_WithNoHand_ReturnsFalse()
        {
            var player = new Player("Shannon", 1.0);
            player.HasBlackJack().Should().BeFalse();
        }

        [Test]
        public void HasBlackJack_WithTwentyOneNoFaceCards_ReturnsTrue()
        {
            var player = new Player("Shannon", 1.0);
            player.Hand.Add(new Player.LiveCard(new Card("Spade", 9), true));
            player.Hand.Add(new Player.LiveCard(new Card("Spade", 10)));
            player.Hand.Add(new Player.LiveCard(new Card("Spade", 2)));
            player.Hand.GetTotal().Should().Be(21);
            player.HasBlackJack().Should().BeTrue();
        }

       [Test]
        public void HasBlackJack_WithTwentyOneWithAceNotBlackJack_ReturnsTrue()
        {
            var player = new Player("Shannon", 1.0);
            player.Hand.Add(new Player.LiveCard(new Card("Spade", 1), true));
            player.Hand.Add(new Player.LiveCard(new Card("Spade", 11)));
            player.Hand.Add(new Player.LiveCard(new Card("Heart", 10)));
            player.Hand.GetTotal().Should().Be(21);
            player.HasBlackJack().Should().BeTrue();
        }

        [Test]
        public void HasBlackJack_BlackJack_ReturnsTrue()
        {
            var player = new Player("Shannon", 1.0);
            player.Hand.Add(new Player.LiveCard(new Card("Spade", 1), true));
            player.Hand.Add(new Player.LiveCard(new Card("Heart", 11)));
            player.Hand.GetTotal().Should().Be(21);
            player.HasBlackJack().Should().BeTrue();
        }

        [Test]
        public void HasBlackJack_23FaceValue_ReturnsFalse()
        {
            var player = new Player("Shannon", 1.0);
            player.Hand.Add(new Player.LiveCard(new Card("Spade", 3), true));
            player.Hand.Add(new Player.LiveCard(new Card("Heart", 11)));
            player.Hand.Add(new Player.LiveCard(new Card("Club", 11)));
            player.Hand.GetTotal().Should().Be(23);
            player.HasBlackJack().Should().BeFalse();
        }

        [Test]
        public void HasBlackJack_FourAces_ReturnsFalse()
        {
            var player = new Player("Shannon", 1.0);
            player.Hand.Add(new Player.LiveCard(new Card("Ace", 1), true));
            player.Hand.Add(new Player.LiveCard(new Card("Heart", 1)));
            player.Hand.Add(new Player.LiveCard(new Card("Club", 1)));
            player.Hand.Add(new Player.LiveCard(new Card("Spade", 1)));

            player.Hand.GetTotal().Should().Be(14);
            player.HasBlackJack().Should().BeFalse();
        }
        [Test]
        public void HasBlackJack_FourAcesAndSeven_ReturnsTrue()
        {
            var player = new Player("Shannon", 1.0);
            player.Hand.Add(new Player.LiveCard(new Card("Ace", 1), true));
            player.Hand.Add(new Player.LiveCard(new Card("Heart", 1)));
            player.Hand.Add(new Player.LiveCard(new Card("Club", 1)));
            player.Hand.Add(new Player.LiveCard(new Card("Spade", 1)));
            player.Hand.Add(new Player.LiveCard(new Card("Spade", 7)));

            player.Hand.GetTotal().Should().Be(21);
            player.HasBlackJack().Should().BeTrue();
        }

        [Test]
        public void IsBusted_WithBlackJack_ReturnsFalse()
        {
            var player = new Player("Shannon", 1.0);
            player.Hand.Add(new Player.LiveCard(new Card("Spade", 1), true));
            player.Hand.Add(new Player.LiveCard(new Card("Heart", 11)));
            player.IsBusted().Should().BeFalse();
        }

        [Test]
        public void IsBusted_23FaceValue_ReturnsTrue()
        {
            var player = new Player("Shannon", 1.0);
            player.Hand.Add(new Player.LiveCard(new Card("Spade", 3),true));
            player.Hand.Add(new Player.LiveCard(new Card("Heart", 11)));
            player.Hand.Add(new Player.LiveCard(new Card("Club", 11)));
            player.Hand.GetTotal().Should().Be(23);
            player.IsBusted().Should().BeTrue();
        }

        [Test]
        public void Winner_PlayerHasBelow21_ReturnsNull()
        {
            var player = new Player("Shannon", 1.0);
            player.Hand.Add(new Player.LiveCard(new Card("Spade", 3), true));
            player.Hand.Add(new Player.LiveCard(new Card("Heart", 11)));
            player.Stayed = true;

            var dealer = new Dealer("Spike");
            dealer.Hand.Add(new Player.LiveCard(new Card("Heart", 3), true));
            dealer.Hand.Add(new Player.LiveCard(new Card("Club", 11)));

            var game = new Game(new List<Player>() {player});
            game._gameDealer = dealer;

            game.Winner().Should().BeNull();
        }

        [Test]
        public void Winner_PlayerHas21Has2Cards_ReturnsPlayer()
        {
            var player = new Player("Shannon", 1.0);
            player.Hand.Add(new Player.LiveCard(new Card("Spade", 1), true));
            player.Hand.Add(new Player.LiveCard(new Card("Heart", 11)));

            var dealer = new Dealer("Spike");
            dealer.Hand.Add(new Player.LiveCard(new Card("Heart", 3), true));
            dealer.Hand.Add(new Player.LiveCard(new Card("Club", 11)));

            var game = new Game(new List<Player>() { player });
            game._gameDealer = dealer;

            game.Winner().Should().Be(player);
        }

        [Test]
        public void Winner_PlayerHas21Has3Cards_ReturnsPlayer()
        {
            var player = new Player("Shannon", 1.0);
            player.Hand.Add(new Player.LiveCard(new Card("Spade", 2), true));
            player.Hand.Add(new Player.LiveCard(new Card("Heart", 11)));
            player.Hand.Add(new Player.LiveCard(new Card("Heart", 9)));

            var dealer = new Dealer("Spike");
            dealer.Hand.Add(new Player.LiveCard(new Card("Heart", 3), true));
            dealer.Hand.Add(new Player.LiveCard(new Card("Club", 11)));

            var game = new Game(new List<Player>() { player });
            game._gameDealer = dealer;

            game.Winner().Should().BeNull();
        }

        [Test]
        public void Winner_PlayerHas21Has3CardsDealerHasBelow17_ReturnsNull()
        {
            var player = new Player("Shannon", 1.0);
            player.Hand.Add(new Player.LiveCard(new Card("Spade", 2), true));
            player.Hand.Add(new Player.LiveCard(new Card("Heart", 11)));
            player.Hand.Add(new Player.LiveCard(new Card("Heart", 9)));

            var dealer = new Dealer("Spike");
            dealer.Hand.Add(new Player.LiveCard(new Card("Heart", 3), true));
            dealer.Hand.Add(new Player.LiveCard(new Card("Club", 11)));

            var game = new Game(new List<Player>() { player });
            game._gameDealer = dealer;

            game.Winner().Should().BeNull();
        }

        [Test]
        public void Winner_PlayerHasBelow17HasStayedDealerHas18_ReturnsDealer()
        {
            var player = new Player("Shannon", 1.0);
            player.Hand.Add(new Player.LiveCard(new Card("Spade", 2), true));
            player.Hand.Add(new Player.LiveCard(new Card("Heart", 11)));
            player.Stayed = true;

            var dealer = new Dealer("Spike");
            dealer.Hand.Add(new Player.LiveCard(new Card("Heart", 8), true));
            dealer.Hand.Add(new Player.LiveCard(new Card("Club", 11)));

            var game = new Game(new List<Player>() { player });
            game._gameDealer = dealer;

            game.Winner().Should().Be(dealer);
        }

        [Test]
        public void Winner_PlayerHas7HasStayedDealerHas18_ReturnsDealer()
        {
            var player = new Player("Shannon", 1.0);
            player.Hand.Add(new Player.LiveCard(new Card("Spade", 2), true));
            player.Hand.Add(new Player.LiveCard(new Card("Heart", 5)));
            player.Stayed = true;

            var dealer = new Dealer("Spike");
            dealer.Hand.Add(new Player.LiveCard(new Card("Heart", 8), true));
            dealer.Hand.Add(new Player.LiveCard(new Card("Club", 11)));

            var game = new Game(new List<Player>() { player });
            game._gameDealer = dealer;

            game.Winner().Should().Be(dealer);
        }

        [Test]
        public void Winner_PlayerHas18HasStayedDealerHas18_ReturnsNull()
        {
            var player = new Player("Shannon", 1.0);
            player.Hand.Add(new Player.LiveCard(new Card("Spade", 10), true));
            player.Hand.Add(new Player.LiveCard(new Card("Heart", 8)));
            player.Stayed = true;

            var dealer = new Dealer("Spike");
            dealer.Hand.Add(new Player.LiveCard(new Card("Heart", 10), true));
            dealer.Hand.Add(new Player.LiveCard(new Card("Club", 8)));

            var game = new Game(new List<Player>() { player });
            game._gameDealer = dealer;

            game.Winner().Should().BeNull();
        }

        [Test]
        public void IsTied_PlayerAndDealerBothHave18_ReturnsTrue()
        {
            var player = new Player("Shannon", 1.0);
            player.Hand.Add(new Player.LiveCard(new Card("Spade", 10), true));
            player.Hand.Add(new Player.LiveCard(new Card("Heart", 8)));
            player.Stayed = true;

            var dealer = new Dealer("Spike");
            dealer.Hand.Add(new Player.LiveCard(new Card("Heart", 10), true));
            dealer.Hand.Add(new Player.LiveCard(new Card("Club", 8)));

            var game = new Game(new List<Player>() { player });
            game._gameDealer = dealer;

            game.IsTied().Should().BeTrue();
        }

        [Test]
        public void IsTied_PlayerAndDealerBothHave16_ReturnsFalse()
        {
            var player = new Player("Shannon", 1.0);
            player.Hand.Add(new Player.LiveCard(new Card("Spade", 10), true));
            player.Hand.Add(new Player.LiveCard(new Card("Heart", 6)));
            player.Stayed = true;

            var dealer = new Dealer("Spike");
            dealer.Hand.Add(new Player.LiveCard(new Card("Heart", 10), true));
            dealer.Hand.Add(new Player.LiveCard(new Card("Club", 6)));

            var game = new Game(new List<Player>() { player });
            game._gameDealer = dealer;

            game.IsTied().Should().BeFalse();
        }

        [Test]
        public void IsTied_PlayerAndDealerHaveDifferingFaceValues_ReturnsFalse()
        {
            var player = new Player("Shannon", 1.0);
            player.Hand.Add(new Player.LiveCard(new Card("Spade", 10), true));
            player.Hand.Add(new Player.LiveCard(new Card("Heart", 2)));
            player.Stayed = true;

            var dealer = new Dealer("Spike");
            dealer.Hand.Add(new Player.LiveCard(new Card("Heart", 10), true));
            dealer.Hand.Add(new Player.LiveCard(new Card("Club", 8)));

            var game = new Game(new List<Player>() { player });
            game._gameDealer = dealer;

            game.IsTied().Should().BeFalse();
        }


        [Test]
        public void MustHit_DealerHas16FaceValues_ReturnsTrue()
        {
            var dealer = new Dealer("Spike");
            dealer.Hand.Add(new Player.LiveCard(new Card("Spade", 11), true));
            dealer.Hand.Add(new Player.LiveCard(new Card("Spade", 2), false));
            dealer.MustHit().Should().BeTrue();
        }
        
    }
}
