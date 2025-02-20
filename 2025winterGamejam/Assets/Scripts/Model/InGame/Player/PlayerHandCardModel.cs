using System;
using System.Collections.Generic;
using Domain.IModel.InGame.Player;
using R3;
using Utility.Module.Option;
using Utility.Structure.InGame;

namespace Model.InGame.Player
{
    public class PlayerHandCardModel: IMutHandCardModel, IMutSelectedCardModel, IDisposable
    {
        public ReactiveProperty<Option<Card>> SelectedCard { get; } =
            new ReactiveProperty<Option<Card>>(Option<Card>.None());

        public ReadOnlyReactiveProperty<Option<Card>> OnSelected => SelectedCard;
        public IReadOnlyList<Card> HandCardsReader => HandCards;
        private List<Card> HandCards { get; } = new List<Card>();
        public Action<Card> OnAddHandCards { get; set; }

        public void StoreNewCard(Card card)
        {
            HandCards.Add(card);
        }

        public void Dispose()
        {
            SelectedCard?.Dispose();
        }

    }
}