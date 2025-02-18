using System;
using System.Collections.Generic;
using Domain.IModel.InGame.Player;
using Domain.IPresenter.InGame.Player;
using IView.InGame;
using ObservableCollections;
using R3;
using Utility.Module.Option;
using Utility.Structure.InGame;
using Object = UnityEngine.Object;

namespace Presenter.InGame.Player
{
    /// <summary>
    /// 手札の変化を画面に反映する
    /// </summary>
    public class CardPresenter : IHandCardEventPresenter, IDisposable
    {
        public CardPresenter
        (
            IPlayerIdModel playerIdModel,
            IHandCardModel handCardModel,
            ICardPositionsView cardPositionsView,
            FactorableCardView factorableCardView
        )
        {
            PlayerIdModel = playerIdModel;
            CardPositionsView = cardPositionsView;
            FactorableCardView = factorableCardView;
            Products = new List<FactorableCardView>();
            SelectedCard = new ReactiveProperty<Option<Card>>(Option<Card>.None());

            SynchronizedView = handCardModel.HandCards
                .CreateView(CreateCardView);
        }

        private FactorableCardView CreateCardView(Card card)
        {
            var instance = Object.Instantiate(FactorableCardView);
            instance.InitHandCard(new PlayerHandCard(PlayerIdModel.PlayerId, card), DeleteCardView);
            Products.Add(instance);

            instance.SelectionEvent += handCard => SetSelectedCard(handCard.CardDesc);
            FixPosition();
            return instance;
        }

        private void DeleteCardView(FactorableCardView cardView)
        {
            cardView.SelectionEvent -= handCard => SetSelectedCard(handCard.CardDesc);
            Products.Remove(cardView);
            Object.Destroy(cardView.gameObject);
            FixPosition();
        }

        private void FixPosition()
        {
            var positions = CardPositionsView.CardPositions;
            for (int i = 0; i < Products.Count; i++)
            {
                var product = Products[i];
                var position = positions[i];

                product.ModelTransform.position = position.position;
            }
        }

        private void SetSelectedCard(Card card)
        {
            var prev = SelectedCard.CurrentValue;
            if (prev.TryGetValue(out var value))
            {
                if (card.IsEqual(value))
                {
                    SelectedCard.Value = Option<Card>.None();
                }
                else
                {
                    SelectedCard.Value = Option<Card>.Some(card);
                }
            }
        }

        public ReadOnlyReactiveProperty<Option<Card>> OnSelectCard => SelectedCard;

        private IPlayerIdModel PlayerIdModel { get; }
        private FactorableCardView FactorableCardView { get; }
        private List<FactorableCardView> Products { get; }
        private ICardPositionsView CardPositionsView { get; }
        private ISynchronizedView<Card, FactorableCardView> SynchronizedView { get; }
        private ReactiveProperty<Option<Card>> SelectedCard { get; }

        public void Dispose()
        {
            SelectedCard?.Dispose();
            SynchronizedView?.Dispose();
        }
    }
}