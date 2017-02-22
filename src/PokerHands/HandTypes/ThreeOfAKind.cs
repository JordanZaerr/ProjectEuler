using System.Linq;

namespace PokerHands
{
    public class ThreeOfAKind : StrategyBase
    {
        public ThreeOfAKind()
        {
            HandFunc = x => x.HasThreeOfKind();
            HighCardFunc = x => x.GetThreeOfAKind().First();
        }
    }
}