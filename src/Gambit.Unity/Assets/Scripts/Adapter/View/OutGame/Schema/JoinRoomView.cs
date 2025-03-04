using Adapter.IView.OutGame.Schema;
using Cysharp.Threading.Tasks;
using Utility.Structure.HttpClient;
using Utility.Structure.HttpClient.Shared;
using Utility.Structure.InGame;

namespace Adapter.View.OutGame.Schema
{
    public class JoinRoomView: RestClient, IJoinRoom
    {
        private const string Path = "";
        protected JoinRoomView(string hostName) : base(hostName)
        {
        }

        public async UniTask<RoomList> GetRoomList()
        {
            return await Get<RoomList>(Path);
        }

        public async UniTask<PlayerId> MakeNewRoom(MakeNewRoomRequest roomName)
        {
            return await PostJson<MakeNewRoomRequest, PlayerId>(Path, roomName);
        }
    }
}