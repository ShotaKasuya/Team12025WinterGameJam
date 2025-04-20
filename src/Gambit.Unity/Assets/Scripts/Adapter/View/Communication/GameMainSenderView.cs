using System;
using Cysharp.Threading.Tasks;
using Gambit.Shared;
using Gambit.Shared.DataTransferObject;
using Gambit.Unity.Adapter.IView.UseCommunication;
using Gambit.Unity.Utility.Structure.InGame;
using MagicOnion;
using MagicOnion.Client;
using UnityEngine;

namespace Gambit.Unity.Adapter.View.Communication
{
    public class GameMainSenderView : IConnectView, ISendSelectedCardView, ILeaveRoomView, IDisposable
    {
        public GameMainSenderView
        (
            GrpcChannelx channel,
            IGameMainReceiver receiver,
            IPlayerIdView playerIdView
        )
        {
            Channel = channel;
            Receiver = receiver;
            PlayerIdView = playerIdView;
        }

        public async UniTask<InitSetting> Connect()
        {
            _gameMainCommunication =
                await StreamingHubClient.ConnectAsync<IGameMainCommunication, IGameMainReceiver>(Channel, Receiver);
            Debug.Log("connected");
            var result = await _gameMainCommunication.JoinAsync();
            Debug.Log("join complete\n" +
                      $"seed: {result.RandomSeed}, player id: {result.PlayerId} ");
            _isConnected = true;
            _localPlayer = new PlayerId(result.PlayerIndex);
            return new InitSetting(result.RandomSeed, result.PlayerIndex, result.PlayerId.Convert());
        }

        public async UniTask SendPlayerCard(PlayerCard playerCard)
        {
            Debug.Log($"send card: {playerCard.ToString()}");
            await UniTask.WaitUntil(() => _gameMainCommunication is not null);
            var sendCard = new PlayerCardTransferObject(
                PlayerIdView.GetPlayerId(playerCard.PlayerId),
                playerCard.Card.Convert()
            );
            await _gameMainCommunication.SendSelectedCardAsync(sendCard);
            Debug.Log("send completed");
        }

        public async UniTask LeaveAsync()
        {
            var playerId = PlayerIdView.GetPlayerId(_localPlayer);
            await _gameMainCommunication.LeaveAsync(playerId);
        }

        private bool _isConnected;
        private PlayerId _localPlayer;
        private GrpcChannelx Channel { get; }
        private IGameMainReceiver Receiver { get; }
        private IGameMainCommunication _gameMainCommunication;
        private IPlayerIdView PlayerIdView { get; }

        public void Dispose()
        {
            if (_isConnected)
            {
                var playerId = PlayerIdView.GetPlayerId(_localPlayer);
                _gameMainCommunication.LeaveAsync(playerId);
            }
            Channel.Dispose();
        }
    }
}