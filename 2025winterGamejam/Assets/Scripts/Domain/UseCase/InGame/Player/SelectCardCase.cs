using System;
using Domain.IModel.InGame.Player;
using Domain.IPresenter.InGame;

namespace Domain.UseCase.InGame.Player
{
    /// <summary>
    /// カードを選択する処理
    /// </summary>
    public class SelectCardCase: IDisposable
    {
        public SelectCardCase
        (
            IHandCardPresenter handCardPresenter,
            IMutSelectedCardModel selectedCardModel
        )
        {
            HandCardPresenter = handCardPresenter;
            SelectedCardModel = selectedCardModel;

            handCardPresenter.OnSelectCard += OnSelect;
        }

        private void OnSelect(HandCardDesc handCardDesc)
        {
            SelectedCardModel.SelectedCard.Value = handCardDesc.Card;
        }
        
        private IHandCardPresenter HandCardPresenter { get; }
        private IMutSelectedCardModel SelectedCardModel { get; }

        public void Dispose()
        {
            HandCardPresenter.OnSelectCard -= OnSelect;
        }
    }
}