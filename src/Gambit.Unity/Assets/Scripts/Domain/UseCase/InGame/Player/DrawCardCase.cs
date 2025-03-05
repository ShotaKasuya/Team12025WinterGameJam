using System;
using Gambit.Unity.Adapter.IModel.Global;
using Gambit.Unity.Adapter.IModel.InGame;
using Gambit.Unity.Adapter.IModel.InGame.Player;
using Gambit.Unity.Structure.Utility.InGame;
using Gambit.Unity.Structure.Utility.InGame.StateMachine;
using R3;
using VContainer.Unity;

namespace Gambit.Unity.Domain.UseCase.InGame.Player
{
    /// <summary>
    /// プレイヤーがカードをドローする処理
    /// </summary>
    public class DrawCardCase : IDisposable, IInitializable
    {
        public DrawCardCase
        (
            IPlayerCountModel playerCountModel,
            IPlayerDeckModel playerDeckModel,
            IMutPlayerHandCardModel playerHandCardModel,
            IGameStateModel gameStateModel
        )
        {
            PlayerDeckModel = playerDeckModel;
            PlayerHandCardModel = playerHandCardModel;
            GameStateModel = gameStateModel;
        }

        public void Initialize()
        {
            _disposable = GameStateModel.GameState
                .Subscribe(state =>
                {
                    if (state == GameStateType.Init)
                    {
                        // FIXME
                        for (int i = 0; i < 4; i++)
                        {
                            OnDraw();
                        }
                    }

                    if (state == GameStateType.DrawCard)
                    {
                        OnDraw();
                    }
                });
        }

        private void OnDraw()
        {
            if (PlayerDeckModel.Deck.Cards.TryPop(out Card card))
            {
                PlayerHandCardModel.StoreNewCard(card);
            }
        }

        private IDisposable _disposable;
        private IPlayerCountModel PlayerCountModel { get; }
        private IPlayerDeckModel PlayerDeckModel { get; }
        private IMutPlayerHandCardModel PlayerHandCardModel { get; }
        private IGameStateModel GameStateModel { get; }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}