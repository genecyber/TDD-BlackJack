using NUnit.Framework;
using TDDBlackJack;
using FluentAssertions;

namespace BlackJack
{
    
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void CreatePlayerWithName_ProducesPlayerWithName()
        {
            var player = new Player("Shannon", 5.0);
            player.Name.Should().Be("Shannon");
        }

        [Test]
        public void Player_New_StayedReturnsFalse()
        {
            var player = new Player("Shannon", 5.0);
            player.HasStayed.Should().BeFalse();
        }

        [Test]
        public void Player_NewStayed_StayedReturnsTrue()
        {
            var player = new Player("Shannon", 5.0);
            player.Stayed = true;
            player.HasStayed.Should().BeTrue();
        }

        [Test]
        public void Player_NewNotStayedButBlackJack_StayedReturnsTrue()
        {
            var player = new Player("Shannon", 5.0);
            player.Hand.Add(new Player.LiveCard(new Card("Spade", 1)));
            player.Hand.Add(new Player.LiveCard(new Card("Spade", 11)));

            player.HasStayed.Should().BeTrue();
        }
       
    }
}
