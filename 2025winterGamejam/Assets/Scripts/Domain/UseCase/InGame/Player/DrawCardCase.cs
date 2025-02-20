using System;
using Domain.IModel.InGame;
using Domain.IModel.InGame.Player;
using Utility.Structure.InGame;
using IMutHandCardModel = Domain.IModel.InGame.Player.IMutHandCardModel;

namespace Domain.UseCase.InGame.Player
{
    /// <summary>
    /// プレイヤーがカードをドローする処理
    /// </summary>
    public class DrawCardCase: IDisposable
    {
        public DrawCardCase
        (
            IDeckModelPlayer deckModel,
            IMutHandCardModel handCardModel,
            IGameStartEventModel gameStartEventModel,
            IDrawCardEventModel drawCardEventModel
        )
        {
            DeckModel = deckModel;
            HandCardModel = handCardModel;
            GameStartEventModel = gameStartEventModel;
            DrawCardEventModel = drawCardEventModel;

            drawCardEventModel.GameDrawCardEvent += OnDraw;
        }
         private void OnDraw()
        {
            if(DeckModel.Deck.Cards.TryPop(out Card card))
            {
                HandCardModel.StoreNewCard(card);
            }
        }

        private IDeckModelPlayer DeckModel { get; }
        private IMutHandCardModel HandCardModel { get; }
        private IGameStartEventModel GameStartEventModel { get; }
        private IDrawCardEventModel DrawCardEventModel { get; }

        public void Dispose()
        {
            DrawCardEventModel.GameDrawCardEvent -= OnDraw;
        }
    }
}