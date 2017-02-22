using System.Collections.Generic;
using System.Linq;

namespace PokerHands
{
    public class GameHand
    {
        private readonly PlayerHand _player1;
        private readonly PlayerHand _player2;
        private readonly List<IStrategy> _winningStrategies = new List<IStrategy>
        {
            new RoyalFlush(),
            new StraightFlush(),
            new FourOfAKind(),
            new FullHouse(),
            new Flush(),
            new Straight(),
            new ThreeOfAKind(),
            new TwoPair(),
            new Pair(),
            new HighCard()
        };

        public GameHand(PlayerHand player1, PlayerHand player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public Player GetWinner()
        {
            var winningHand = _winningStrategies
                .Where(x => x.Matches(_player1, _player2))
                .Select(x => x.Winner(_player1, _player2))
                .SkipWhile(x => x == null).Take(1).First();

            return _player1.Equals(winningHand) ? Player.Player1 : Player.Player2;
        }
    }
}