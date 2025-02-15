using System.Collections.Generic;

namespace Structure.InGame
{
    public struct HandCard
    {
        public List<Card> Cards{ get; }
        public HandCard(List<Card> cards)
        {
            Cards = cards;
        }
    }
    
    /// <summary>
    /// 手札のカードについての情報を持つ
    /// プレイヤーの `id`
    /// 手札の中の `id`
    /// </summary>
    public struct PlayerHandCard
    {
        public PlayerHandCard(int playerId, Card card)
        {
            PlayerId = playerId;
            CardDesc = card;
        }
        public int PlayerId { get; }
        public Card CardDesc { get; }
    }
    
}