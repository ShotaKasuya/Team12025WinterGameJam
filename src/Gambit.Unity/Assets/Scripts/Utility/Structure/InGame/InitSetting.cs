namespace Gambit.Unity.Utility.Structure.InGame
{
    public struct InitSetting
    {
        public InitSetting(int roomSeed, PlayerId playerId)
        {
            RoomSeed = roomSeed;
            PlayerId = playerId;
        }
        public readonly int RoomSeed;
        public readonly PlayerId PlayerId;
    }
}