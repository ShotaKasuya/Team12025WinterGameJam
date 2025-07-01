using System;
using Gambit.Unity.Adapter.IModel.Global;
using Gambit.Unity.Adapter.IModel.InGame.Player;
using Gambit.Unity.Adapter.IView.InGame;
using Gambit.Unity.Adapter.IView.OutGame.Title;
using Gambit.Unity.Adapter.IView.UseCommunication;
using Gambit.Unity.Utility.Structure.InGame;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Gambit.Unity.Adapter.Controller.OutGame
{
    public class MatchingController : IInitializable, IDisposable
    {
        public MatchingController
        (
            IMatchConfPanelView matchConfPanelView,
            IMatchEventView matchEventView,
            IConnectView connectView,
            IMutRoomInfoModel roomInfoModel,
            IIdInitializableModel idInitializableModel
        )
        {
            MatchConfPanelView = matchConfPanelView;
            MatchEventView = matchEventView;
            ConnectView = connectView;
            RoomInfoModel = roomInfoModel;
            IdInitializableModel = idInitializableModel;
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
            IdInitializableModel.SetPlayerId(new PlayerId(result.PlayerIndex - 1));
        }

        private IMatchConfPanelView MatchConfPanelView { get; }
        private IMatchEventView MatchEventView { get; }
        private IConnectView ConnectView { get; }
        private IMutRoomInfoModel RoomInfoModel { get; }
        private IIdInitializableModel IdInitializableModel { get; }

        public void Dispose()
        {
            MatchConfPanelView.OnStartGame -= Connect;
        }
    }
}