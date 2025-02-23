using System;
using System.Collections.Generic;
using Domain.IModel.InGame.Judgement;
using Domain.IModel.InGame.Player;
using R3;
using Utility.Module.Option;
using Utility.Structure.InGame;
using IMutSelectedCardModel = Domain.IModel.InGame.Player.IMutSelectedCardModel;

namespace Model.InGame.Player
{
    public class PlayerHandCardModel : IMutPlayerHandCardModel, IMutSelectedCardModel, IDisposable
    {
        public PlayerHandCardModel
        (
            IPlayerIdModel playerIdModel,
            IMutHandCardModel handCardModel
        )
        {
            PlayerIdModel = playerIdModel;
            HandCardModel = handCardModel;
        }

        public ReactiveProperty<Option<Card>> SelectedCard { get; } = new(Option<Card>.None());
        public ReadOnlyReactiveProperty<Option<Card>> OnSelected => SelectedCard;
        public IReadOnlyList<Card> HandCardsReader => HandCardModel.HandCardReader[PlayerIdModel.PlayerId.Id].Cards;
        public Action<Card> OnAddHandCards { get; set; }

        public void StoreNewCard(Card card)
        {
            HandCardModel.StoreNewCard(PlayerIdModel.PlayerId.Id, card);
            OnAddHandCards?.Invoke(card);
        }

        public void Dispose()
        {
            SelectedCard?.Dispose();
        }

        private IPlayerIdModel PlayerIdModel { get; }
        private IMutHandCardModel HandCardModel { get; }
    }
}