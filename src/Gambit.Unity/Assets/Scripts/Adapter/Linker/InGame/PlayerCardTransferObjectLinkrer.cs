using System;
using Gambit.Shared;
using Gambit.Unity.Adapter.IModel.InGame.Player;
using Gambit.Unity.Adapter.IView.InGame.CardFactory;
using Gambit.Unity.Structure.Utility.InGame;
using Gambit.Unity.Adapter.IModel.InGame.Judgement;
using Gambit.Unity.Module.Utility.Module.Option;
using Gambit.Unity.Adapter.IView.InGame;
using VContainer.Unity;

namespace Gambit.Unity.Adapter.Linker.InGame
{
    public class PlayerCardTransferObjectLinker:IInitializable,IDisposable
    {
        public PlayerCardTransferObjectLinker
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