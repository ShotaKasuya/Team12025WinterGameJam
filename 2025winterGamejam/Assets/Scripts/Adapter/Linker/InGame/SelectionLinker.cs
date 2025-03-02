using System;
using Adapter.IModel.InGame.Judgement;
using Adapter.IView.InGame;
using Utility.Module.Option;
using Utility.Structure.InGame;
using VContainer.Unity;

namespace Adapter.Linker.InGame
{
    public class SelectionLinker : IInitializable, IDisposable
    {
        public SelectionLinker
        (
            IHandCardPoolView handCardPoolView,
            IMutSelectedCardModel selectedCardModel
        )
        {
            HandCardPoolView = handCardPoolView;
            SelectedCardModel = selectedCardModel;
        }

        public void Initialize()
        {
            HandCardPoolView.OnStore += SetLinker;
            HandCardPoolView.OnPop += RemoveLinker;
        }

        private void SetLinker(NewProductCardView view)
        {
            view.SelectionEvent += OnSelect;
        }

        private void RemoveLinker(NewProductCardView view)
        {
            view.SelectionEvent -= OnSelect;
        }

        private void OnSelect(PlayerCard selectedCard)
        {
            var currentSelect = SelectedCardModel.GetSelection(selectedCard.PlayerId);
            var apply = Option<PlayerCard>.Some(selectedCard);
            if (currentSelect.TryGetValue(out var card))
            {
                if (card.Card == selectedCard.Card)
                {
                    apply = Option<PlayerCard>.None();
                }
            }

            SelectedCardModel.StorePlayerSelection(selectedCard.PlayerId.Id, apply);
            ApplyView(selectedCard.PlayerId, apply);
        }

        private void ApplyView(PlayerId playerId, Option<PlayerCard> selected)
        {
            var views = HandCardPoolView.GetViewList(playerId);
            foreach (var cardView in views)
            {
                cardView.TurnOff();
            }

            if (selected.TryGetValue(out var card))
            {
                foreach (var cardView in views)
                {
                    if (cardView.Card.Card == card.Card)
                    {
                        cardView.TurnOn();
                    }
                }
            }
        }

        private IHandCardPoolView HandCardPoolView { get; }
        private IMutSelectedCardModel SelectedCardModel { get; }

        public void Dispose()
        {
            HandCardPoolView.OnPop -= SetLinker;
            HandCardPoolView.OnStore -= RemoveLinker;
        }
    }
}