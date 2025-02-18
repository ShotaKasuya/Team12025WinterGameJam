using System;
using Domain.IModel.InGame.Player;
using Domain.IPresenter.InGame.Player;
using R3;
using Utility.Module.Option;
using Utility.Structure.InGame;

namespace Domain.UseCase.InGame.Player
{
    /// <summary>
    /// カードを選択する処理
    /// </summary>
    public class SelectCardCase: IDisposable
    {
        public SelectCardCase
        (
            IHandCardEventPresenter handCardPresenter,
            IMutSelectedCardModel selectedCardModel
        )
        {
            SelectedCardModel = selectedCardModel;

            var disposable = handCardPresenter.OnSelectCard
                .Subscribe(
                    OnSelect
                );

            Disposable = disposable;
        }

        private void OnSelect(Option<Card> handCardDesc)
        {
            if (handCardDesc.TryGetValue(out var desc))
            {
                SelectedCardModel.SelectedCard.Value = Option<Card>.Some(desc);
            }
            SelectedCardModel.SelectedCard.Value = Option<Card>.None();
        }

        private IMutSelectedCardModel SelectedCardModel { get; }
        private IDisposable Disposable { get; }

        public void Dispose()
        {
            Disposable?.Dispose();
        }
    }
}