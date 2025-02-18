using System;
using Domain.IModel.InGame.Player;
using ObservableCollections;
using R3;
using Utility.Module.Option;
using Utility.Structure.InGame;

namespace Model.InGame.Player
{
    public class PlayerHandCardModel: IMutHandCardModel, IMutSelectedCardModel, IDisposable
    {
        public ReactiveProperty<Option<Card>> SelectedCard { get; } =
            new ReactiveProperty<Option<Card>>(Option<Card>.None());
        public ObservableList<Card> HandCards { get; } = new ObservableList<Card>();
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