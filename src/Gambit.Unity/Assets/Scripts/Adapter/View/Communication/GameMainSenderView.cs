using System;
using Cysharp.Threading.Tasks;
using Gambit.Shared;
using Gambit.Unity.Adapter.IView.UseCommunication;
using Gambit.Unity.Structure.Utility.InGame;
using MagicOnion;
using MagicOnion.Client;
using UnityEngine;

namespace Gambit.Unity.Adapter.View.Communication
{
    public class GameMainSenderView : IConnectView, ISendSelectedCardView, IDisposable
    {
        public GameMainSenderView
        (
            GrpcChannelx channel,
            IGameMainReceiver receiver
        )
        {
            Channel = channel;
            Receiver = receiver;
        }

        public async UniTask<InitSetting> Connect()
        {
            _gameMainCommunication =
                await StreamingHubClient.ConnectAsync<IGameMainCommunication, IGameMainReceiver>(Channel, Receiver);
            Debug.Log("connected");
            var result = await _gameMainCommunication.JoinAsync();
            Debug.Log("join complete\n" +
                      $"seed: {result.RandomSeed}, player id: {result.PlayerId}, index: {result.PlayerIndex}");
            return new InitSetting(result.RandomSeed, result.PlayerId.Convert(), result.PlayerIndex);
        }

        public async void SendPlayerCard(PlayerCard playerCard)
        {
            Debug.Log($"send card: {playerCard.ToString()}");
            await UniTask.WaitUntil(() => _gameMainCommunication is not null);
            await _gameMainCommunication.SendSelectedCardAsync(playerCard.Convert());
            Debug.Log("send completed");
        }

        private GrpcChannelx Channel { get; }
        private IGameMainReceiver Receiver { get; }
        private IGameMainCommunication _gameMainCommunication;

        public void Dispose()
        {
            Channel?.Dispose();
        }
    }
}