using System.Linq;

namespace PokerHands
{
    public class FourOfAKind : StrategyBase
    {
        public FourOfAKind()
        {
            HandFunc = x => x.HasFourOfKind();
            HighCardFunc = x => x.GetFourOfAKind().First();
        }
    }
}