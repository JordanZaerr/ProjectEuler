using System;
using System.IO;
using System.Linq;
using Shared;

namespace PokerHands
{
    //376
    class PokerHands
    {
        static void Main()
        {
            //~80ms
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        //Convoluted. Has at least one bug around 'two pairs' but doesn't affect outcome.
        private static void FirstAttempt()
        {
            var hands = File.ReadAllLines("hands.txt")
                .SelectMany(x => x.Split('\n'))
                .ToList();

            var count = 0;
            foreach (var hand in hands)
            {
                var cards = hand.Split(' ');

                var player1 = new PlayerHand(cards.Take(5));
                var player2 = new PlayerHand(cards.Skip(5).Take(5));
                var game = new GameHand(player1, player2);

                if (game.GetWinner() == Player.Player1)
                    count++;
            }
            Console.WriteLine($"Player 1 won {count} games!");
        }
    }
}
