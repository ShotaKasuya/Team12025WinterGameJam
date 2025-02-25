using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Domain.IModel.InGame;
using R3;
using Utility.Structure.InGame;
using VContainer.Unity;

namespace Domain.UseCase.InGame.Flow
{
    public class JudgeStateFlowCase : IInitializable, IDisposable
    {
        public JudgeStateFlowCase
        (
            IMutGameStateModel gameStateModel
        )
        {
            GameStateModel = gameStateModel;
        }

        public void Initialize()
        {
            _disposable = GameStateModel.GameState
                .Where(x => x == GameStateType.Judge)
                .SubscribeAwait(async (_, token) => { await StartAsync(token); });
        }

        public async UniTask StartAsync(CancellationToken cancellation = new CancellationToken())
        {
            await UniTask.WaitUntil(() => GameStateModel.GameState.CurrentValue == GameStateType.Judge,
                cancellationToken: cancellation);

            // todo 演出

            GameStateModel.SetGameState(GameStateType.AddPoint);
        }

        private IDisposable _disposable;
        private IMutGameStateModel GameStateModel { get; }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}