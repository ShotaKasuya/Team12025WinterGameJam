using Cysharp.Threading.Tasks;
using Utility.Structure.HttpClient.Schema;
using Utility.Structure.InGame;

namespace Utility.Structure.HttpClient.Client
{
    public class JoinRoomView : RestClient, IJoinRoom
    {
        public JoinRoomView(string hostName) : base(hostName)
        {
        }

        public UniTask<RoomList> GetRoomList()
        {
            return Get<RoomList>("");
        }

        public UniTask<RoomList> GetRoomListWhereName(string roomName)
        {
            return Get<RoomList>("");
        }

        public UniTask<PlayerId> MakeNewRoom(string roomName)
        {
            return Get<PlayerId>("");
        }
    }
}