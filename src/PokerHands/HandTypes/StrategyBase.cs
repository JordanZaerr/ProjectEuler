using System;

namespace PokerHands
{
    public abstract class StrategyBase : IStrategy
    {
        protected Func<PlayerHand, bool> HandFunc { get; set; }
        protected Func<PlayerHand, Card> HighCardFunc { get; set; }

        protected StrategyBase()
        {
            HandFunc = x => true;
            HighCardFunc = x => x.HighCard;
        }

        public bool Matches(PlayerHand hand1, PlayerHand hand2)
        {
            return HandFunc(hand1) || HandFunc(hand2);
        }

        public virtual PlayerHand Winner(PlayerHand hand1, PlayerHand hand2)
        {
            return CheckHand(hand1, hand2) ?? CheckHighCard(hand1, hand2);
        }

        protected PlayerHand CheckHand(PlayerHand hand1, PlayerHand hand2)
        {
            if (HandFunc(hand1) && !HandFunc(hand2))
                return hand1;
            if (HandFunc(hand2) && !HandFunc(hand1))
                return hand2;
            return null;
        }

        protected virtual PlayerHand CheckHighCard(PlayerHand hand1, PlayerHand hand2)
        {
            if (HighCardFunc(hand1).Value > HighCardFunc(hand2).Value)
                return hand1;
            if (HighCardFunc(hand2).Value > HighCardFunc(hand1).Value)
                return hand2;
            return null;
        }
    }
}