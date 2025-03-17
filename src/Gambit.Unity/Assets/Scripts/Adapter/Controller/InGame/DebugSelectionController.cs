using System;
using Gambit.Unity.Adapter.IModel.InGame.Judgement;
using Gambit.Unity.Adapter.IView.InGame;
using Gambit.Unity.Adapter.IView.InGame.CardFactory;
using Gambit.Unity.Utility.Module.Option;
using Gambit.Unity.Utility.Structure.InGame;
using VContainer.Unity;

namespace Gambit.Unity.Adapter.Controller.InGame
{
    /// <summary>
    /// デバッグ用にカードが誰のものであるかを問わず選択できる
    /// </summary>
    public class DebugSelectionController : IInitializable, IDisposable
    {
        public DebugSelectionController
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

        private void SetLinker(ProductCardView view)
        {
            view.SelectionEvent += OnSelect;
        }

        private void RemoveLinker(ProductCardView view)
        {
            view.SelectionEvent -= OnSelect;
        }

        private void OnSelect(PlayerCard selectedCard)
        {
            var currentSelect = SelectedCardModel.GetSelection(selectedCard.PlayerIndex);
            var apply = Option<PlayerCard>.Some(selectedCard);

            if (currentSelect.TryGetValue(out var card))
            {
                if (card.Card == selectedCard.Card)
                {
                    apply = Option<PlayerCard>.None();
                }
            }

            SelectedCardModel.StorePlayerSelection(selectedCard.PlayerIndex, apply);
            ApplyView(selectedCard.PlayerIndex, apply);
        }

        private void ApplyView(int index, Option<PlayerCard> selected)
        {
            var views = HandCardPoolView.GetViewList(index);
            
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