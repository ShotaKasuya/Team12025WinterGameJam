using Domain.IAdaptor.Factory;
using Domain.IView.InGame;
using Structure.InGame;
using UnityEngine;

namespace Domain.Adapter.Factory
{
    public class CardViewFactory: ICardFactory
    {
        public CardViewFactory
        (
            FactorableCardView cardView
        )
        {
            CardView = cardView;
        }

        public FactorableCardView BuildCard(PlayerHandCard playerHandCard)
        {
            var instance = Object.Instantiate(CardView);
            instance.InitHandCard(playerHandCard);
            
            return instance;
        }

        private FactorableCardView CardView { get; }
    }
}