using Adapter.IModel.Global;
using Adapter.IModel.InGame.Judgement;
using Domain.IUseCase.InGame;
using Utility.Structure.InGame;

namespace Domain.UseCase.InGame
{
    public class DrawCardCase : IDrawCase
    {
        public DrawCardCase
        (
            IPlayerCountModel playerCountModel,
            IMutDeckModel deckModel,
            IMutHandCardModel handCardModel
        )
        {
            PlayerCountModel = playerCountModel;
            DeckModel = deckModel;
            HandCardModel = handCardModel;
        }

        public Card[] DrawCard()
        {
            var cards = new Card[PlayerCountModel.PlayerCount];
            for (var i = 0; i < PlayerCountModel.PlayerCount; i++)
            {
                if (DeckModel.DeckReader[i].Cards.TryPop(out var card))
                {
                    cards[i] = card;
                    HandCardModel.StoreNewCard(i, card);
                }
            }

            return cards;
        }

        private IPlayerCountModel PlayerCountModel { get; }
        private IMutDeckModel DeckModel { get; }
        private IMutHandCardModel HandCardModel { get; }
    }
}