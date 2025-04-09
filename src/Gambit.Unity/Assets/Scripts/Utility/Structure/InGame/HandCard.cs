using System.Collections.Generic;

namespace Gambit.Unity.Utility.Structure.InGame
{
    public struct HandCard
    {
        public List<PlayerCard> Cards { get; set; }

        public HandCard(List<PlayerCard> cards)
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
        public PlayerHandCard(PlayerId playerId, Card card)
        {
            PlayerId = playerId;
            CardDesc = card;
        }

        public PlayerId PlayerId { get; }
        public Card CardDesc { get; }
    }
}