using Gambit.Unity.Adapter.IModel.Global;
using Gambit.Unity.Adapter.IView.OutGame.Title;
using Gambit.Unity.Adapter.IView.UseCommunication;
using VContainer.Unity;

namespace Gambit.Unity.Adapter.Linker.OutGame
{
    public class MatchingLinker: IInitializable
    {
        public MatchingLinker
        (
            IMatchConfPanelView matchConfPanelView,
            IConnectView connectView,
            IMutRoomInfoModel roomInfoModel
        )
        {
            MatchConfPanelView = matchConfPanelView;
            ConnectView = connectView;
            RoomInfoModel = roomInfoModel;
        }
        
        public void Initialize()
        {
            MatchConfPanelView.OnStartGame += Connect;
        }

        private async void Connect()
        {
            var result = await ConnectView.Connect();
            RoomInfoModel.Init(result.RoomSeed, result.PlayerId);
        }
        
        private IMatchConfPanelView MatchConfPanelView { get; }
        private IConnectView ConnectView { get; }
        private IMutRoomInfoModel RoomInfoModel { get; }
    }
}