using System.Collections.Generic;
using NUnit.Framework;
using TDDBlackJack;
using FluentAssertions;
using System;

namespace BlackJack
{
    [TestFixture]
    public class GameTests
    {

        [Test]
        public void NewGameWithOnePlayerShouldHaveOnlyOnePlayer()
        {
            var myGame = new Game((new List<Player>(){new Player("Shannon",1.0)}));
            myGame.NumberOfPlayers.Should().Be(1);
        }

        [Test]
        public void NewGameWithEmptyPlayerList_Excepts()
        {
            Action act = () => new Game(new List<Player>());
            act.ShouldThrow<Exception>();
        }
        [Test]
        public void NewGameWithFivePlayersShouldThrowException()
        {
            var p1 = new Player("a",1.0);
            var p2 = new Player("b", 1.0);
            var p3 = new Player("c", 1.0);
            var p4 = new Player("d", 1.0);
            var p5 = new Player("e", 1.0);
            var players = new List<Player>(){p1, p2, p3, p4, p5};
            Action act = () => new Game(players);
            act.ShouldThrow<Exception>();
        }

        [Test]
        public void NewGameWithBrokePlayer_CreatesGameWithOnePlayer()
        {
            var p1 = new Player("a", 1.0);
            var p2 = new Player("b", 0.0);
            var players = new List<Player>() { p1, p2};
            var game = new Game(players);

            game.NumberOfPlayers.Should().Be(1);
        }

        [Test]
        public void NewGameWithBrokePlayer_CreatesMessagesToOffendingPlayer()
        {
            var p1 = new Player("a", 1.0);
            var p2 = new Player("b", 0.0);
            var players = new List<Player>() { p1, p2 };
            var game = new Game(players);

            game.NumberOfPlayers.Should().Be(1);
            game.Messages.Should().HaveCount(1);
            game.Messages[0].SentTo.Should().Be(p2);
        }

        [Test]
        public void GameWithOnePlayer_DealTwoCardsToEachPlayer_Leaves48CardsInGameDeck()
        {
            var p1 = new Player("a", 1.0);
            var game = new Game(new List<Player>(){p1});
            game.Start();
            game.GameDeck.CardsRemaining.Should().HaveCount(48);
        }
    }
}
