using NUnit.Framework;
using TDDBlackJack;
using FluentAssertions;
using System;

namespace BlackJack
{
    [TestFixture]
    public class DeckTests
    {


        [Test]
        public void DrawingOneCardResultsInOneCardBeingRemovedFromDeck()
        {
            Deck theDeck = new Deck();
            int number = 1;
            theDeck.Draw(number);
            theDeck.CardsRemaining.Count.Should().Be(51);
        }

        [Test]
        public void DrawingThreeCardsShouldThrowException()
        {
            Deck theDeck = new Deck();

            int number = 3;
            bool isValid = true;

            try
            {
                theDeck.Draw(number);
            }
            catch (Exception e)
            {
                isValid = false;
            }

            isValid.Should().BeFalse();               
        }

        [Test]
        public void DrawingNegativeNumberOfCardsShouldThrowException()
        {
            Deck theDeck = new Deck();
            
            const int number = -1;
            var isValid = true;

            try
            {
                theDeck.Draw(number);
            }
            catch (Exception e)
            {
                isValid = false;
            }

            isValid.Should().BeFalse();
        }

        [Test]
        public void DrawingCardFromDeckRemovesItFromDeck()
        {
            var theDeck = new Deck();

            var dealt = theDeck.Draw();

            theDeck.CardsRemaining.Should().NotContain(dealt);
        }

        [Test]
        public void DrawingTopCardFromShuffledDeckDoesNotReturnAceOfSpades()
        {
            var theDeck = new Deck();
            theDeck.Shuffle();

            var dealt = theDeck.Draw();

            dealt.Should().NotBe(new Card("Spade",1));
        }

        [Test]
        public void DrawingTopCardsFromTwoShuffledDecksShouldBeDifferent()
        {
            var theDeck = new Deck();
            theDeck.Shuffle();
            var anotherDeck = new Deck();
            anotherDeck.Shuffle();

            var card1 = theDeck.Draw();
            var card2 = anotherDeck.Draw();

            card1.Should().NotBe(card2);
        }
    }
}
