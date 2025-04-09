using MessagePack;

namespace Gambit.Shared.DataTransferObject
{
    [MessagePackObject]
    public struct PlayerInitInfoTransferObject
    {
        public PlayerInitInfoTransferObject
        (
            PlayerIdTransferObject playerId,
            int randomSeed
        )
        {
            PlayerId = playerId;
            RandomSeed = randomSeed;
        }
        
        /// <summary>
        /// 割り振られたid
        /// </summary>
        [Key(0)]
        public readonly PlayerIdTransferObject PlayerId;

        /// <summary>
        /// デッキ生成で使用するシード
        /// </summary>
        [Key(2)]
        public readonly int RandomSeed;
    }
}