namespace PokerHands
{
    public class Straight : StrategyBase
    {
        public Straight()
        {
            HandFunc = x => x.HasStraight();
        }
    }
}