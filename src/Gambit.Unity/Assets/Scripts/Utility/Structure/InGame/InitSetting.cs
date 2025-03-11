namespace Gambit.Unity.Structure.Utility.InGame
{
    public struct InitSetting
    {
        public InitSetting(int roomSeed, PlayerId playerId, int playerIndex)
        {
            RoomSeed = roomSeed;
            PlayerId = playerId;
            PlayerIndex = playerIndex;
        }
        public readonly int RoomSeed;
        public readonly PlayerId PlayerId;
        public readonly int PlayerIndex;
    }
}