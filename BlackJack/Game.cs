using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackJackTest;

namespace TDDBlackJack
{
    public class Game
    {
        public Game(ICollection<Player> players)
        {
            Messages = new List<Message>();
            if (players.Count < 1)
                throw new Exception("Players must exist in order to play the game.");
            if (players.Count > 4 || NumberOfPlayers + players.Count > 4)
            {
                throw new Exception("Table Full");
            }

            foreach (Player player in players)
            {
                if (player.Bank > 0)
                    _gamePlayers.Add(player);
                else
                {
                    var msg = new Message("You need to have some cash to play at this table.", player, _gameDealer);
                    Messages.Add(msg);
                }
            }
        }

        public void Start()
        {
            DealTwoCardsToEachPlayer();
            DealTo(_gameDealer, false);
            DealTo(_gameDealer, true);
        }

        public void DealTwoCardsToEachPlayer()
        {
            foreach (Player gamePlayer in _gamePlayers)
            {
                DealTo(gamePlayer,false);
                DealTo(gamePlayer,true);
            }
        }
        private void DealTo(Player player, bool faceUp)
        {
            var card = GameDeck.Draw();
            player.Hand.Add(new Player.LiveCard {Card = card, FaceUp = faceUp});
        }
        public int NumberOfPlayers
        {
            get { return _gamePlayers.Count(); }
        }

        public List<Message> Messages { get; set; }
        public readonly List<Player> _gamePlayers = new List<Player>();
        public Dealer _gameDealer = new Dealer("Spike");
        public readonly Deck GameDeck = new Deck();

        public bool GameOver{get
        {
            if (this.Winner() == _gameDealer || this.Winner() == _gamePlayers[0])
                return true;
            return false;
        }}
    }
}
