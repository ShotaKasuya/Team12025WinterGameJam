using System;
using Domain.IModel.InGame;
using Structure.InGame;

namespace Domain.UseCase.InGame
{
    public class DrawCardCase: IDisposable
    {
        public DrawCardCase
        (
            IDeckModel deckModel,
            IHandCard handCard,
            IGameStartEventModel gameStartEventModel,
            IDrawCardEventModel drawCardEventModel
        )
        {
            DeckModel = deckModel;
            HandCard = handCard;
            GameStartEventModel = gameStartEventModel;
            DrawCardEventModel = drawCardEventModel;

            drawCardEventModel.GameDrawCardEvent += OnDraw;
        }

        private void OnDraw()
        {
            for (int i = 0; i < DeckModel.Decks.Count; i++)
            {
                var deck = DeckModel.Decks[i];
                var handCard = HandCard.HandCards[i];

                Draw(deck, handCard);
            }
        }

        private void Draw(Deck deck, HandCard handCard)
        {
            if (deck.Cards.TryPop(out var card))
            {
                handCard.Cards.Add(card);
            }
        }

        private IDeckModel DeckModel { get; }
        private IHandCard HandCard { get; }
        private IGameStartEventModel GameStartEventModel { get; }
        private IDrawCardEventModel DrawCardEventModel { get; }

        public void Dispose()
        {
            DrawCardEventModel.GameDrawCardEvent -= OnDraw;
        }
    }
}