namespace Gambit.Shared.DataTransferObject
{
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
        public readonly PlayerIdTransferObject PlayerId;
        /// <summary>
        /// デッキ生成で使用するシード
        /// </summary>
        public readonly int RandomSeed;
    }
}