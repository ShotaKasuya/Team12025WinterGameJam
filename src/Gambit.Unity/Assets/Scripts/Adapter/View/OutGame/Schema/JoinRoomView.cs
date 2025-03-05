using Cysharp.Threading.Tasks;
using Gambit.Unity.Adapter.IView.OutGame.Schema;
using Gambit.Unity.Structure.Utility.HttpClient;
using Gambit.Unity.Structure.Utility.HttpClient.Shared;
using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Adapter.View.OutGame.Schema
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