namespace PokerHands
{
    public class RoyalFlush : StrategyBase
    {
        public RoyalFlush()
        {
            HandFunc = x => x.HasRoyalFlush();
        }
        public bool Matches(PlayerHand hand1, PlayerHand hand2)
        {
            return hand1.HasRoyalFlush() || hand2.HasRoyalFlush();
        }

        public PlayerHand Winner(PlayerHand hand1, PlayerHand hand2)
        {
            if (hand1.HasRoyalFlush() && !hand2.HasRoyalFlush())
                return hand1;
            if(hand2.HasRoyalFlush() && !hand1.HasRoyalFlush())
                return hand2;
            return null;
        }
    }
}