using System;
using Domain.IModel.InGame;
using Structure.InGame;
using Domain.IModel.InGame.Player;
namespace Domain.UseCase.InGame.Player
{
    /// <summary>
    /// プレイヤーがカードをドローする処理
    /// </summary>
    public class DrawCardCase
    {
        public DrawCardCase
        (
            IDeckModelPlayer deckModel,
            IHandCardModelPlayer handCardModel,
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
                HandCardModel.HandCards.Cards.Add(card);
            }
        }

        private IDeckModelPlayer DeckModel { get; }
        private IHandCardModelPlayer HandCardModel { get; }
        private IGameStartEventModel GameStartEventModel { get; }
        private IDrawCardEventModel DrawCardEventModel { get; }

        public void Dispose()
        {
            DrawCardEventModel.GameDrawCardEvent -= OnDraw;
        }
    }
}