using System.Linq;

namespace PokerHands
{
    public class FullHouse : StrategyBase
    {
        public FullHouse()
        {
            HandFunc = x => x.HasFullHouse();
            HighCardFunc = x => x.GetThreeOfAKind().First();
        }
    }
}