using System.Collections.Generic;
using Domain.IAdapter.InGame;
using Domain.IPresenter.InGame;
using IView.InGame;
using Structure.InGame;

namespace Adapter.InGame
{
    public class CardFactory: ICardFactory
    {
        public CardFactory
        (
            FactorableCardView cardView,
            IReadOnlyList<ICardReceivable> cardReceivable
        )
        {
            CardView = cardView;
            Receivable = cardReceivable;
        }

        public void BuildCard(PlayerHandCard playerHandCard)
        {
            var instance = UnityEngine.Object.Instantiate(CardView);
            instance.InitHandCard(playerHandCard, RemoveProduct);
            AddEventProvider(instance);
        }

        private void RemoveProduct(FactorableCardView product)
        {
            for (int i = 0; i < Receivable.Count; i++)
            {
                Receivable[i].ReleaseCard(product);
            }
        }
        
        private void AddEventProvider(FactorableCardView product)
        {
            for (int i = 0; i < Receivable.Count; i++)
            {
                Receivable[i].ReceiveCard(product);
            }
        }

        private FactorableCardView CardView { get; }
        private IReadOnlyList<ICardReceivable> Receivable { get; }
    }
}