using Domain.IModel.InGame.Player;
using IView.InGame;
using Utility.Module.Option;
using Utility.Structure.InGame;

namespace Presenter.InGame.Player
{
    /// <summary>
    /// カードの選択を反映する
    /// </summary>
    public class SelectedCardPresenter
    {
        public SelectedCardPresenter
        (
            ICardFactory cardFactory,
            IMutSelectedCardModel selectedCardModel
        )
        {
            CardFactory = cardFactory;
            SelectedCardModel = selectedCardModel;

            cardFactory.OnCreateView += AddView;
        }

        private void ApplyView(Option<Card> card)
        {
            var views = CardFactory.Products;
            for (int i = 0; i < views.Count; i++)
            {
                var view = views[i];

                if (card.TryGetValue(out var value))
                {
                    if (value.IsEqual(view.Card))
                    {
                        view.TurnOn();
                    }
                    else
                    {
                        view.TurnOff();
                    }
                }
                else
                {
                    view.TurnOff();
                }
            }
        }

        private void OnSelect(Card card)
        {
            var apply = Option<Card>.Some(card);
            var currentSelect = SelectedCardModel.OnSelected.CurrentValue;
            if (currentSelect.TryGetValue(out var value))
            {
                if (card.IsEqual(value))
                {
                    apply=Option<Card>.None();
                }
            }
            ApplyView(apply);
            SelectedCardModel.SelectedCard.Value = apply;
        }

        private void AddView(ProductCardView cardView)
        {
            cardView.SelectionEvent += OnSelect;
        }

        private ICardFactory CardFactory { get; }
        private IMutSelectedCardModel SelectedCardModel { get; }
    }
}