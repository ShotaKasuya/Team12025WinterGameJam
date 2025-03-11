using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Adapter.IModel.Global
{
    public interface IRoomInfoModel
    {
        public int RoomSeed { get; }
        public PlayerId Owner { get; }
    }

    public interface IMutRoomInfoModel
    {
        public void Init(int roomSeed, PlayerId owner);
    }
}