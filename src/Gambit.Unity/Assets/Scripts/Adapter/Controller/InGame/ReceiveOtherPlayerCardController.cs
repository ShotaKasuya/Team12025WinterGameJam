using System;
using Gambit.Unity.Adapter.IModel.InGame.Judgement;
using Gambit.Unity.Adapter.IView.InGame;
using Gambit.Unity.Utility.Module.Option;
using Gambit.Unity.Utility.Structure.InGame;
using VContainer.Unity;

namespace Gambit.Unity.Adapter.Controller.InGame
{
    public class ReceiveOtherPlayerCardController:IInitializable,IDisposable
    {
        public ReceiveOtherPlayerCardController
        (
            IMutSelectedCardModel selectedCardModel,
            IGetSentCardStateView getSentCardStateView
        )
        {
            SelectedCardModel = selectedCardModel;
            GetSentCardStateView = getSentCardStateView;
        }
        
        public void Initialize()
        {
            GetSentCardStateView.GetSentCard += SetSentCard;
        }

        private void SetSentCard(PlayerCard playerCard)
        {
            var apply = Option<PlayerCard>.Some(playerCard);
            SelectedCardModel.StorePlayerSelection(playerCard.PlayerIndex, apply);
        }
        
        private IMutSelectedCardModel SelectedCardModel{get;}
        private IGetSentCardStateView GetSentCardStateView { get; }
    
        public void Dispose()
        {
            GetSentCardStateView.GetSentCard -= SetSentCard;
        }
    }
}