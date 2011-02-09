using NUnit.Framework;
using TDDBlackJack;
using System;
using FluentAssertions;

namespace BlackJack
{
    [TestFixture]
    public class CardTests
    {
        [Test]
        public void NewCardHasSuitAndValue()
        {
            var card = new Card();

            card.Value.Should().NotBeNull();
            card.Suits().Should().NotBeNull();
        }

        [Test]
        public void NewCardCreatesACardWithASuit()
        {
            var card = new Card();

            card.Suit.Should().NotBe("");
        }

        [Test]
        public void NewCardAceOfDiamondsCreatesCardOfSuitDiamonds()
        {
            var card = new Card("Diamond", 4);

            card.Suit.Should().Be("Diamond");
        }

        [Test]
        public void NewCardAceOfDiamondsCreatesCardOfValueThirteen()
        {
            var card = new Card("Diamond", 2);

            card.Value.Value.Should().Be(2);
        }

        [Test]
        public void NewCardOfValue14ShouldThrowException()
        {

            var isvalid = true;
            try
            {
                var card = new Card("Spade", 14);
            }
            catch (Exception e)
            {
                isvalid = false;
            }
            isvalid.Should().BeFalse();
        }
    }
}
