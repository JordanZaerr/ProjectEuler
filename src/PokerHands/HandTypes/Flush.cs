namespace PokerHands
{
    public class Flush : StrategyBase
    {
        public Flush()
        {
            HandFunc = x => x.HasFlush();
        }
    }
}