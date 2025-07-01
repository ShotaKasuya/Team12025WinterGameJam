namespace Gambit.Unity.Utility.Structure.InGame
{
    public struct InitSetting
    {
        public InitSetting(int roomSeed, int playerIndex, PlayerId playerId)
        {
            RoomSeed = roomSeed;
            PlayerIndex = playerIndex;
            PlayerId = playerId;
        }
        public readonly int RoomSeed;
        public readonly int PlayerIndex;
        public readonly PlayerId PlayerId;
    }
}