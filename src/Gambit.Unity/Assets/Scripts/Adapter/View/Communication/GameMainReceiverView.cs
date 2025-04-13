using System;
using Gambit.Shared;
using Gambit.Shared.DataTransferObject;
using Gambit.Unity.Adapter.IView.InGame;
using Gambit.Unity.Adapter.IView.UseCommunication;
using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Adapter.View.Communication
{
    public class GameMainReceiverView : IGameMainReceiver, IGetSentCardStateView, IMatchEventView
    {
        public GameMainReceiverView(IPlayerIdView playerIdView, IPlayerIdInitializeView playerIdInitializeView)
        {
            PlayerIdView = playerIdView;
            PlayerIdInitializeView = playerIdInitializeView;
        }

        private IPlayerIdView PlayerIdView { get; }
        private IPlayerIdInitializeView PlayerIdInitializeView { get; }
        public Action<PlayerCard> GetSentCard { get; set; }
        public Action OnMatched { get; set; }

        public void OnMatch(PlayersInfoTransferObject playersInfo)
        {
            OnMatched?.Invoke();
            PlayerIdInitializeView.Init(playersInfo.PlayerIds);
        }

        public void MatchResult(string machResult)
        {
            Console.WriteLine($" VS {machResult}");
        }

        public void SendSelectedCard(PlayerCardTransferObject playerCardTransferObject)
        {
            var playerId = PlayerIdView.GetPlayerId(playerCardTransferObject.PlayerId);
            var playerCard = new PlayerCard(playerId, playerCardTransferObject.Card.Convert());
            InvokeGetSentCardState(playerCard);
        }

        private void InvokeGetSentCardState(PlayerCard playerCard)
        {
            GetSentCard.Invoke(playerCard);
        }
    }
}