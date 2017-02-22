using System.Linq;

namespace PokerHands
{
    public class Pair : StrategyBase
    {
        public Pair()
        {
            HandFunc = x => x.HasPair();
            HighCardFunc = x => x.GetPair().First();
        }
    }
}