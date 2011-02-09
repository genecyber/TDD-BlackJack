using System;
using System.Collections.Generic;
using System.Linq;
using BlackJackTest;

namespace TDDBlackJack
{
    public static class Extension
    {
        public static bool HasBlackJack(this Player player)
        {
            if (player.Hand == null || player.Hand.Count < 2)
                return false;
            int total = GetTotal(player.Hand);
            return total == 21;
        }
        public static bool IsBusted(this Player player)
        {
            int total = player.Hand.GetTotal();
            return total > 21;
        }

        public static int GetTotal(this IEnumerable<Player.LiveCard> playerHand)
        {
            var total = 0;
            var hand = playerHand.OrderBy(a => a.Card.Value.Value);
            foreach (Player.LiveCard liveCard in hand.Reverse())
            {
                var currentCard = liveCard.Card.Value.FaceValue;

                if (liveCard.Card.Value.Name == "Ace" && total + currentCard > 21)
                    currentCard = 1;
                total += currentCard;
            }
            return total;
        }

        public static Player Winner(this Game game)
        {
            if (BlackJackFromStart(game._gameDealer))
                return game._gameDealer;
            if (BlackJackFromStart(game._gamePlayers[0]))
                return game._gamePlayers[0];

            if (game._gameDealer.MustHit())
                return null;

            if (!game._gameDealer.MustHit() && game._gamePlayers[0].HasStayed && game._gameDealer.Hand.GetTotal() > game._gamePlayers[0].Hand.GetTotal())
                return game._gameDealer;

            if (!game._gameDealer.MustHit() && game._gamePlayers[0].HasStayed && game._gameDealer.Hand.GetTotal() < game._gamePlayers[0].Hand.GetTotal())
                return game._gamePlayers[0];

            return null;
        }

        public static bool IsTied(this Game game)
        {
            if (game._gamePlayers[0].Hand.GetTotal() == game._gameDealer.Hand.GetTotal() && !game._gameDealer.MustHit())
                return true;
            return false;
        }

        private static bool BlackJackFromStart(Player gamePlayer)
        {
            if (gamePlayer.HasBlackJack() && gamePlayer.Hand.Count == 2)
                return true;
            return false;
        }

        public static bool MustHit(this Dealer dealer)
        {
            if (dealer.Hand.GetTotal() < 17)
                return true;
            return false;
        }
    }
}
