using System.Collections.Generic;
using Gambit.Unity.Adapter.IModel.Global;
using Gambit.Unity.Adapter.IModel.InGame.Judgement;
using Gambit.Unity.Adapter.IModel.InGame.Setting;
using Gambit.Unity.Domain.IUseCase.InGame;
using Gambit.Unity.Module.Utility.Module.Option;
using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Domain.UseCase.InGame
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
                var cards = DrawCard().Unwrap();
                for (int j = 0; j < cards.Length; j++)
                {
                    handCards[j].Cards.Add(cards[j]);
                }
            }

            return handCards;
        }

        public Option<Card[]> DrawCard()
        {
            if (DeckModel.DeckReader[0].Cards.Count == 0)
            {
                return Option<Card[]>.None();
            }
            
            var cards = new Card[PlayerCountModel.PlayerCount];
            for (var i = 0; i < PlayerCountModel.PlayerCount; i++)
            {
                if (DeckModel.DeckReader[i].Cards.TryPop(out var card))
                {
                    cards[i] = card;
                    HandCardModel.StoreNewCard(i, card);
                }
            }

            return Option<Card[]>.Some(cards);
        }

        private IPlayerCountModel PlayerCountModel { get; }
        private IHandCardSettingModel HandCardSettingModel { get; }
        private IMutDeckModel DeckModel { get; }
        private IMutHandCardModel HandCardModel { get; }
    }
}