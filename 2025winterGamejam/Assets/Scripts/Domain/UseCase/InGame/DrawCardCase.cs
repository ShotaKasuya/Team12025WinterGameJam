using System.Collections.Generic;
using Adapter.IModel.Global;
using Adapter.IModel.InGame;
using Adapter.IModel.InGame.Judgement;
using Adapter.IModel.InGame.Setting;
using Domain.IUseCase.InGame;
using Utility.Structure.InGame;

namespace Domain.UseCase.InGame
{
    public class DrawCardCase : IInitHandCardCase, IDrawCase
    {
        public DrawCardCase
        (
            IPlayerCountModel playerCountModel,
            IHandCardSettingModel handCardSettingModel,
            IMutDeckModel deckModel,
            IMutHandCardModel handCardModel
        )
        {
            PlayerCountModel = playerCountModel;
            HandCardSettingModel = handCardSettingModel;
            DeckModel = deckModel;
            HandCardModel = handCardModel;
        }
        
        public HandCard[] InitHand()
        {
            var handCards = new HandCard[PlayerCountModel.PlayerCount];
            for (int i = 0; i < handCards.Length; i++)
            {
                handCards[i] = new HandCard(new List<Card>());
            }

            for (int i = 0; i < HandCardSettingModel.InitHandCard; i++)
            {
                var cards = DrawCard();
                for (int j = 0; j < cards.Length; j++)
                {
                    handCards[j].Cards.Add(cards[j]);
                }
            }

            return handCards;
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
        private IHandCardSettingModel HandCardSettingModel { get; }
        private IMutDeckModel DeckModel { get; }
        private IMutHandCardModel HandCardModel { get; }
    }
}