using System;
using System.Collections.Generic;
using Domain.IModel.InGame.Judgement;
using Domain.IModel.InGame.Player;
using R3;
using Utility.Module.Option;
using Utility.Structure.InGame;

namespace Model.InGame.Player
{
    public class PlayerHandCardModel : IMutPlayerHandCardModel, IMutPlayerSelectedCardModel, IDisposable
    {
        public PlayerHandCardModel
        (
            PlayerId playerIdModel,
            IMutHandCardModel handCardModel,
            IMutSelectedCardModel selectedCardModel
        )
        {
            PlayerIdModel = playerIdModel;
            HandCardModel = handCardModel;
            SelectedCardModel = selectedCardModel;
        }

        private ReactiveProperty<Option<Card>> SelectedCard { get; } = new(Option<Card>.None());
        public ReadOnlyReactiveProperty<Option<Card>> OnSelected => SelectedCard;
        public void SetSelectedCard(Option<Card> card)
        {
            SelectedCard.Value = card;
            SelectedCardModel.StorePlayerSelection(PlayerIdModel.Id, card);
        }

        public IReadOnlyList<Card> HandCardsReader => HandCardModel.HandCardReader[PlayerIdModel.Id].Cards;
        public Action<Card> OnAddHandCards { get; set; }

        public void StoreNewCard(Card card)
        {
            HandCardModel.StoreNewCard(PlayerIdModel.Id, card);
            OnAddHandCards?.Invoke(card);
        }

        public void Dispose()
        {
            SelectedCard?.Dispose();
        }

        private PlayerId PlayerIdModel { get; }
        private IMutHandCardModel HandCardModel { get; }
        private IMutSelectedCardModel SelectedCardModel { get; }
    }
}