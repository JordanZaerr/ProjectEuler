using System.Linq;

namespace PokerHands
{
    public class TwoPair : StrategyBase
    {
        public TwoPair()
        {
            HandFunc = x => x.HasTwoPair();
            //This doesn't account for a matching one or two pairs
            HighCardFunc = x => x.GetTwoPair().First();
        }
    }
}