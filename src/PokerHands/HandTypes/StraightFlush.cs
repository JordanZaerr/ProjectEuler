namespace PokerHands
{
    public class StraightFlush : StrategyBase
    {
        public StraightFlush()
        {
            HandFunc = x => x.HasStraightFlush();
        }
    }
}