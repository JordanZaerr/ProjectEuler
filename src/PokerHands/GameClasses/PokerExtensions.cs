using System.Collections.Generic;
using System.Linq;

namespace PokerHands
{
    public static class PokerExtensions
    {
        public static IEnumerable<Card> GetPair(this PlayerHand hand)
        {
            return
                hand.Cards.GroupBy(x => x.Value)
                    .Where(x => x.Count() == 2)
                    .OrderByDescending(x => x.Key)
                    .FirstOrDefault() ?? Enumerable.Empty<Card>();
        }

        public static bool HasPair(this PlayerHand hand)
        {
            return hand.GetPair().Any();
        }

        public static IEnumerable<Card> GetTwoPair(this PlayerHand hand)
        {
            return hand.Cards.GroupBy(x => x.Value)
                .Where(x => x.Count() == 2)
                .OrderByDescending(x => x.Key)
                .SelectMany(x => x);
        }

        public static bool HasTwoPair(this PlayerHand hand)
        {
            return hand.GetTwoPair().Count() == 4;
        }

        public static IEnumerable<Card> GetThreeOfAKind(this PlayerHand hand)
        {
            return hand.Cards.GroupBy(x => x.Value).FirstOrDefault(x => x.Count() == 3)
                   ?? Enumerable.Empty<Card>();
        }

        public static bool HasThreeOfKind(this PlayerHand hand)
        {
            return hand.GetThreeOfAKind().Any();
        }

        public static IEnumerable<Card> GetFourOfAKind(this PlayerHand hand)
        {
            return hand.Cards.GroupBy(x => x.Value).FirstOrDefault(x => x.Count() == 4)
                   ?? Enumerable.Empty<Card>();
        }

        public static bool HasFourOfKind(this PlayerHand hand)
        {
            return hand.GetFourOfAKind().Any();
        }

        public static bool HasFlush(this PlayerHand hand)
        {
            return hand.Cards.All(x => x.Suit == hand.Cards.First().Suit);
        }

        public static bool HasFullHouse(this PlayerHand hand)
        {
            return HasTwoPair(hand) && HasThreeOfKind(hand) && hand.Cards.GroupBy(x => x.Value).Count() == 2;
        }

        public static bool HasStraight(this PlayerHand hand)
        {
            return
                hand.Cards.Select(x => x.Value)
                    .Cast<int>()
                    .SequenceEqual(Enumerable.Range((int)hand.Cards.Last().Value, 5).Reverse());
        }

        public static bool HasStraightFlush(this PlayerHand hand)
        {
            return HasFlush(hand) && HasStraight(hand);
        }

        public static bool HasRoyalFlush(this PlayerHand hand)
        {
            return hand.Cards.Select(x => x.Value)
                       .SequenceEqual(new[]
                       {
                           CardValue.Ace, CardValue.King,
                           CardValue.Queen, CardValue.Jack,
                           CardValue.Ten
                       }) && HasFlush(hand);
        }
    }
}