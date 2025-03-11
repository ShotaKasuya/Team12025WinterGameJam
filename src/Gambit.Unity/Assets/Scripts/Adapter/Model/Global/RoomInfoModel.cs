using Gambit.Unity.Adapter.IModel.Global;
using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Adapter.Model.Global
{
    public class RoomInfoModel: IRoomInfoModel, IMutRoomInfoModel
    {
        public int RoomSeed { get; private set; }
        public PlayerId Owner { get; private set; }
        
        public void Init(int roomSeed, PlayerId owner)
        {
            RoomSeed = roomSeed;
            Owner = owner;
        }
    }
}