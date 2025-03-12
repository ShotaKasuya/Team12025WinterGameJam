using System;
using Gambit.Unity.Adapter.IModel.Global;
using Gambit.Unity.Adapter.IModel.InGame.Player;
using Gambit.Unity.Adapter.IView.InGame;
using Gambit.Unity.Adapter.IView.OutGame.Title;
using Gambit.Unity.Adapter.IView.UseCommunication;
using Gambit.Unity.Structure.Utility.InGame;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Gambit.Unity.Adapter.Linker.OutGame
{
    public class MatchingLinker : IInitializable, IDisposable
    {
        public MatchingLinker
        (
            IMatchConfPanelView matchConfPanelView,
            IMatchEventView matchEventView,
            IConnectView connectView,
            IMutRoomInfoModel roomInfoModel,
            IIdInitializableModel playerIdModel
        )
        {
            MatchConfPanelView = matchConfPanelView;
            MatchEventView = matchEventView;
            ConnectView = connectView;
            RoomInfoModel = roomInfoModel;
            IdInitializableModel = playerIdModel;
        }

        public void Initialize()
        {
            MatchConfPanelView.OnStartGame += Connect;
            MatchEventView.OnMatched += () => SceneManager.LoadScene("GameScene");
        }

        private async void Connect()
        {
            var result = await ConnectView.Connect();
            RoomInfoModel.Init(result.RoomSeed, result.PlayerId);
            IdInitializableModel.SetPlayerId(result.PlayerId, new PlayerId(result.PlayerIndex));
        }

        private IMatchConfPanelView MatchConfPanelView { get; }
        private IMatchEventView MatchEventView { get; }
        private IConnectView ConnectView { get; }
        private IMutRoomInfoModel RoomInfoModel { get; }
        private IIdInitializableModel IdInitializableModel { get; }

        public void Dispose()
        {
            MatchConfPanelView.OnStartGame -= Connect;
            MatchEventView.OnMatched -= () => SceneManager.LoadScene("GameScene");
        }
    }
}