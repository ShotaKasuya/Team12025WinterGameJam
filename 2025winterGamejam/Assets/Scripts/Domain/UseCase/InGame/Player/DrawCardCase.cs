using System;
using Domain.IModel.InGame;
using Domain.IModel.InGame.Player;
using Utility.Structure.InGame;
using VContainer.Unity;

namespace Domain.UseCase.InGame.Player
{
    /// <summary>
    /// プレイヤーがカードをドローする処理
    /// </summary>
    public class DrawCardCase : IDisposable, IInitializable
    {
        public DrawCardCase
        (
            IPlayerDeckModel playerDeckModel,
            IMutPlayerHandCardModel playerHandCardModel,
            IGameStartEventModel gameStartEventModel,
            IDrawCardEventModel drawCardEventModel
        )
        {
            PlayerDeckModel = playerDeckModel;
            PlayerHandCardModel = playerHandCardModel;
            GameStartEventModel = gameStartEventModel;
            DrawCardEventModel = drawCardEventModel;
        }

        public void Initialize()
        {
            DrawCardEventModel.GameDrawCardEvent += OnDraw;
        }

        private void OnDraw()
        {
            if (PlayerDeckModel.Deck.Cards.TryPop(out Card card))
            {
                PlayerHandCardModel.StoreNewCard(card);
            }
        }

        private IPlayerDeckModel PlayerDeckModel { get; }
        private IMutPlayerHandCardModel PlayerHandCardModel { get; }
        private IGameStartEventModel GameStartEventModel { get; }
        private IDrawCardEventModel DrawCardEventModel { get; }

        public void Dispose()
        {
            DrawCardEventModel.GameDrawCardEvent -= OnDraw;
        }
    }
}