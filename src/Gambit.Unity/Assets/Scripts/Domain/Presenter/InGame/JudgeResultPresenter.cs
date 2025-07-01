using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Gambit.Unity.Adapter.IView.InGame;
using Gambit.Unity.Adapter.IView.InGame.CardFactory;
using Gambit.Unity.Domain.IPresenter.InGame;
using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Domain.Presenter.InGame
{
    public class JudgeResultPresenter : IJudgeResultPresenter
    {
        public JudgeResultPresenter
        (
            IDrawCardPoolView drawCardPoolView,
            IWinCardPoolView winCardPoolView,
            ISelectedCardPoolView selectedCardPoolView
        )
        {
            DrawCardPoolView = drawCardPoolView;
            WinCardPoolView = winCardPoolView;
            SelectedCardPoolView = selectedCardPoolView;
        }

        public async UniTask PresentResult(BattleResult result)
        {
            var views = SelectedCardPoolView.PopAllCardViews();
            foreach (var cardView in views)
            {
                cardView.ShowFace();
            }

            await UniTask.WaitForSeconds(0.5f);
            // 引き分け
            if (result.Winner.IsNone)
            {
                await StoreCards(views, async view => { await DrawCardPoolView.StoreNewCard(view); });

                return;
            }

            // 勝者あり
            await StoreCards(views, async view =>
            {
                view.ChangeOwner(result.Winner.Unwrap());
                await UniTask.WaitForSeconds(0.1f);
                WinCardPoolView.StoreNewCard(view);
            });
            await StoreCards(DrawCardPoolView.PopAllCardViews(), async view =>
            {
                view.ChangeOwner(result.Winner.Unwrap());
                await UniTask.WaitForSeconds(0.1f);
                WinCardPoolView.StoreNewCard(view);
            });
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private async UniTask StoreCards(IEnumerable<ProductCardView> cardViews,
            Func<ProductCardView, UniTask> storeFunc)
        {
            var lastTask = UniTask.CompletedTask;
            foreach (var cardView in cardViews)
            {
                lastTask = storeFunc.Invoke(cardView);
            }

            await lastTask;
        }

        private IDrawCardPoolView DrawCardPoolView { get; }
        private IWinCardPoolView WinCardPoolView { get; }
        private ISelectedCardPoolView SelectedCardPoolView { get; }
    }
}