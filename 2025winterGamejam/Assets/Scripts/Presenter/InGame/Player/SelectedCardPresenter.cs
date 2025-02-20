using Domain.IModel.InGame.Player;
using IView.InGame;
using R3;
using UnityEngine;
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
            ISelectedCardModel selectedCardModel
        )
        {
            CardFactory = cardFactory;
            SelectedCardModel = selectedCardModel;

            SelectedCardModel.OnSelected
                .Subscribe(x =>
                {
                    Log(x);
                });
            cardFactory.OnCreateView += AddView;
        }

        private void Log(Option<Card> card)
        {
            Debug.Log("VAR");
        }

        private void AddView(ProductCardView cardView)
        {
            
        }

        private void OnSelect(Card card)
        {
            
        }
        
        private ICardFactory CardFactory { get; }
        private ISelectedCardModel SelectedCardModel { get; }
    }
}