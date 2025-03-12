using MessagePack;

namespace Gambit.Shared.DataTransferObject
{
    [MessagePackObject]
    public struct PlayerInitInfoTransferObject
    {
        public PlayerInitInfoTransferObject
        (
            PlayerIdTransferObject playerId,
            int playerIndex,
            int randomSeed
        )
        {
            PlayerId = playerId;
            PlayerIndex = playerIndex;
            RandomSeed = randomSeed;
        }
        
        /// <summary>
        /// 割り振られたid
        /// </summary>
        [Key(0)]
        public readonly PlayerIdTransferObject PlayerId;

        /// <summary>
        /// 部屋に何番目に入ったプレイヤーかを判別する
        /// </summary>
        [Key(1)]
        public readonly int PlayerIndex;
        /// <summary>
        /// デッキ生成で使用するシード
        /// </summary>
        [Key(2)]
        public readonly int RandomSeed;
    }
}