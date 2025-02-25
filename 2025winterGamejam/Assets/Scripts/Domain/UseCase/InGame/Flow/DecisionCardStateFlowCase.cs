using System;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Domain.IModel.InGame;
using Domain.IModel.InGame.Judgement;
using R3;
using Utility.Structure.InGame;
using VContainer.Unity;

namespace Domain.UseCase.InGame.Flow
{
    public class DecisionCardStateFlowCase : IInitializable, IDisposable
    {
        public DecisionCardStateFlowCase
        (
            IMutGameStateModel gameStateModel,
            ISelectedCardModel selectedCardModel
        )
        {
            GameStateModel = gameStateModel;
            SelectedCardModel = selectedCardModel;
        }

        public void Initialize()
        {
            _disposable = GameStateModel.GameState
                .Where(x => x == GameStateType.DecisionCard)
                .SubscribeAwait(async (_, token) => { await StartAsync(token); });
        }

        public async UniTask StartAsync(CancellationToken cancellation = new CancellationToken())
        {
            await UniTask.WaitUntil(() =>
                GameStateModel.GameState.CurrentValue == GameStateType.DecisionCard, cancellationToken: cancellation);
            await UniTask.WaitUntil(() => { return SelectedCardModel.SelectedCards.All(x => x.IsSome); },
                cancellationToken: cancellation);

            GameStateModel.SetGameState(GameStateType.Judge);
        }

        private IDisposable _disposable;
        private IMutGameStateModel GameStateModel { get; }
        private ISelectedCardModel SelectedCardModel { get; }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}