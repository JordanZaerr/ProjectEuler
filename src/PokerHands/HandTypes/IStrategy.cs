namespace PokerHands
{
    public interface IStrategy
    {
        bool Matches(PlayerHand hand1, PlayerHand hand2);
        PlayerHand Winner(PlayerHand hand1, PlayerHand hand2);
    }
}