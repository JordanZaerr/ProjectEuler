using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Shared;

namespace PokerHands
{
    [DebuggerDisplay("{Value} of {Suit}")]
    public class Card : IComparable<Card>
    {
        public static readonly ReadOnlyDictionary<string, CardValue> Values = new Dictionary<string, CardValue>
        {
            {"2", CardValue.Two}, {"3", CardValue.Three}, {"4", CardValue.Four}, {"5", CardValue.Five},
            {"6", CardValue.Six}, {"7", CardValue.Seven}, {"8", CardValue.Eight}, {"9", CardValue.Nine},
            {"T", CardValue.Ten}, {"J", CardValue.Jack}, {"Q", CardValue.Queen}, {"K", CardValue.King}, {"A", CardValue.Ace}
        }.AsReadOnly();
        public static readonly  ReadOnlyDictionary<char, CardSuit> Suites = new Dictionary<char, CardSuit>
        {
            {'C', CardSuit.Clubs},
            {'S', CardSuit.Spades},
            {'H', CardSuit.Hearts},
            {'D', CardSuit.Diamonds}
        }.AsReadOnly();

        public Card(string card)
        {
            Value = Values[card.First().ToString()];
            Suit = Suites[card.Last()];
        }

        public CardValue Value { get; set; }

        public CardSuit Suit { get; set; }

        public int CompareTo(Card other)
        {
            if (Value > other.Value)
                return 1;
            if (other.Value > Value)
                return -1;
            return 0;
        }
    }
}