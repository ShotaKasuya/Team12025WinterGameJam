using System;
using Gambit.Unity.Adapter.IModel.InGame.Judgement;
using Gambit.Unity.Adapter.IModel.InGame.Player;
using Gambit.Unity.Adapter.IView.InGame.Ui;
using VContainer.Unity;

namespace Gambit.Unity.Adapter.Controller.InGame
{
    /// <summary>
    /// デッキの残りカード数を表示に反映する
    /// </summary>
    public class RemainCardController: IInitializable, IDisposable
    {
        public RemainCardController
        (
            IPlayerIdModel playerIdModel,
            IDeckChangeEventModel deckChangeEventModel,
            IRemainCardView remainCardView
        )
        {
            PlayerIdModel = playerIdModel;
            DeckChangeEventModel = deckChangeEventModel;
            RemainCardView = remainCardView;
        }
        
        public void Initialize()
        {
            DeckChangeEventModel.OnChange += OnChange;
        }

        private void OnChange(IDeckChangeEventModel.Context context)
        {
            if (PlayerIdModel.PlayerId != context.PlayerId)
            {
                return;
            }
            
            RemainCardView.SetRemainCardCount(context.RemainCardCount);
        }
        
        private IPlayerIdModel PlayerIdModel { get; }
        private IDeckChangeEventModel DeckChangeEventModel { get; }
        private IRemainCardView RemainCardView { get; }

        public void Dispose()
        {
            DeckChangeEventModel.OnChange -= OnChange;
        }
    }
}