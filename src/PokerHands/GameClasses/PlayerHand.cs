using System.Collections.Generic;
using System.Linq;
using Shared;

namespace PokerHands
{
    public class PlayerHand 
    {
        public PlayerHand(IEnumerable<string> cards)
        {
            Cards = cards.Select(x => new Card(x)).OrderByDescending(x => x.Value).ToList();
        }

        public List<Card> Cards { get; }

        public Card HighCard => Cards.First();

        protected bool Equals(PlayerHand other)
        {
            return Equals(Cards, other.Cards);
        }

        public override int GetHashCode()
        {
            return Cards.Select(x => x.Value.ToString() + x.Suit.ToString()).Join().GetHashCode();
        }
    }
}