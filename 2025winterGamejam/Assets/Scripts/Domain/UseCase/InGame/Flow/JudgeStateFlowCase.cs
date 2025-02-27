using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Domain.IModel.Global;
using Domain.IModel.InGame;
using Domain.IModel.InGame.Judgement;
using Domain.IView.InGame;
using R3;
using Utility.Structure.InGame;
using VContainer.Unity;

namespace Domain.UseCase.InGame.Flow
{
    public class JudgeStateFlowCase : IInitializable, IDisposable
    {
        public JudgeStateFlowCase
        (
            IPlayerCountModel playerCountModel,
            IMutGameStateModel gameStateModel,
            ISelectedCardModel selectedCardModel,
            ICardReleaseView cardReleaseView
        )
        {
            PlayerCountModel = playerCountModel;
            GameStateModel = gameStateModel;
            CardReleaseView = cardReleaseView;
            SelectedCardModel = selectedCardModel;
        }

        public void Initialize()
        {
            _disposable = GameStateModel.GameState
                .Where(x => x == GameStateType.Judge)
                .SubscribeAwait(async (_, token) => { await JudgeFlow(token); });
        }

        private async UniTask JudgeFlow(CancellationToken cancellation = new CancellationToken())
        {
            await UniTask.WaitUntil(() => GameStateModel.GameState.CurrentValue == GameStateType.Judge,
                cancellationToken: cancellation);

            // todo 演出
            
            for (int i = 0; i < PlayerCountModel.PlayerCount; i++)
            {
                var card = SelectedCardModel.SelectedCards[i].Unwrap();
                CardReleaseView.Release(new PlayerId(i), card);
            }

            GameStateModel.SetGameState(GameStateType.AddPoint);
        }

        private IDisposable _disposable;
        private IPlayerCountModel PlayerCountModel { get; }
        private IMutGameStateModel GameStateModel { get; }
        private ICardReleaseView CardReleaseView { get; }
        private ISelectedCardModel SelectedCardModel { get; }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}