using Gambit.Shared;
using Gambit.Unity.Adapter.IView.UseCommunication;
using Gambit.Unity.Structure.Utility.InGame;
using MagicOnion;
using MagicOnion.Client;

namespace Gambit.Unity.Adapter.View.Communication
{
    public class GameMainSenderView : IConnectView, ISendSelectedCardView
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

        public async void Connect()
        {
            _gameMainCommunication =
                await StreamingHubClient.ConnectAsync<IGameMainCommunication, IGameMainReceiver>(Channel, Receiver);
        }

        public async void SendPlayerCard(PlayerCard playerCard)
        {
            await _gameMainCommunication.SendSelectedCardAsync(playerCard.Convert());
        }

        private GrpcChannelx Channel { get; }
        private IGameMainReceiver Receiver { get; }
        private IGameMainCommunication _gameMainCommunication;
    }
}