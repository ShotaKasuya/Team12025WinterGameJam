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
    public class AddPointStateFlowCase : IInitializable, IDisposable
    {
        public AddPointStateFlowCase
        (
            IMutGameStateModel gameStateModel,
            IHandCardModel handCardModel
        )
        {
            GameStateModel = gameStateModel;
            HandCardModel = handCardModel;
        }

        public void Initialize()
        {
            _disposable = GameStateModel.GameState
                .Where(x => x == GameStateType.AddPoint)
                .SubscribeAwait(async (_, token) => { await StartAsync(token); });
        }

        public async UniTask StartAsync(CancellationToken cancellation = new CancellationToken())
        {
            while (true)
            {
                await UniTask.WaitUntil(() => GameStateModel.GameState.CurrentValue == GameStateType.AddPoint,
                    cancellationToken: cancellation);

                GameStateType transitionTo;
                if (HandCardModel.HandCardReader.All(x => x.Cards.Count == 0))
                {
                    transitionTo = GameStateType.End;
                }
                else
                {
                    transitionTo = GameStateType.DrawCard;
                }

                GameStateModel.SetGameState(transitionTo);
            }
        }

        private IDisposable _disposable;
        private IMutGameStateModel GameStateModel { get; }
        private IHandCardModel HandCardModel { get; }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}