using System;
using Gambit.Shared;
using Gambit.Shared.DataTransferObject;
using Gambit.Unity.Adapter.IView.InGame;
using Gambit.Unity.Adapter.IView.UseCommunication;
using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Adapter.View.Communication
{
    public class GameMainReceiverView : IGameMainReceiver, IGetSentCardStateView, IGetDeclarationView, IMatchEventView
    {
        public GameMainReceiverView(IPlayerIdView playerIdView, IPlayerIdInitializeView playerIdInitializeView)
        {
            PlayerIdView = playerIdView;
            PlayerIdInitializeView = playerIdInitializeView;
        }

        private IPlayerIdView PlayerIdView { get; }
        private IPlayerIdInitializeView PlayerIdInitializeView { get; }
        public Action<PlayerCard> GetSentCard { get; set; }
        public Action<PlayerId, Rank> OtherPlayerDeclaration { get; set; }
        public Action OnMatched { get; set; }

        public void OnMatch(PlayersInfoTransferObject playersInfo)
        {
            OnMatched?.Invoke();
            PlayerIdInitializeView.Init(playersInfo.PlayerIds);
        }

        public void ReceiveSelectedCard(PlayerCardTransferObject playerCardTransferObject)
        {
            var playerId = PlayerIdView.GetPlayerId(playerCardTransferObject.PlayerId);
            var playerCard = new PlayerCard(playerId, playerCardTransferObject.Card.Convert());
            InvokeGetSentCardState(playerCard);
        }

        public void ReceiveDeclarationCardAsync(PlayerIdTransferObject playerIdTransferObject, RankTransferObject rankTransferObject)
        {
            var playerId = PlayerIdView.GetPlayerId(playerIdTransferObject);
            var rank = rankTransferObject.Convert();
            
            OtherPlayerDeclaration?.Invoke(playerId,rank);
        }

        private void InvokeGetSentCardState(PlayerCard playerCard)
        {
            GetSentCard.Invoke(playerCard);
        }
    }
}