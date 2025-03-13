using System.Collections.Generic;
using Gambit.Unity.Adapter.IModel.Global;
using Gambit.Unity.Adapter.IModel.InGame.Judgement;
using Gambit.Unity.Adapter.IModel.InGame.Player;
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
            IPlayerDictionaryModel playerDictionaryModel,
            IHandCardSettingModel handCardSettingModel,
            IMutDeckModel deckModel,
            IMutHandCardModel handCardModel
        )
        {
            PlayerCountModel = playerCountModel;
            PlayerDictionaryModel = playerDictionaryModel;
            HandCardSettingModel = handCardSettingModel;
            DeckModel = deckModel;
            HandCardModel = handCardModel;
        }
        
        public HandCard[] InitHand()
        {
            var handCards = new HandCard[PlayerCountModel.PlayerCount];
            for (int i = 0; i < handCards.Length; i++)
            {
                handCards[i] = new HandCard(new List<PlayerCard>());
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

        public Option<PlayerCard[]> DrawCard()
        {
            if (DeckModel.DeckReader[0].Cards.Count == 0)
            {
                return Option<PlayerCard[]>.None();
            }
            
            var cards = new PlayerCard[PlayerCountModel.PlayerCount];
            for (var i = 0; i < PlayerCountModel.PlayerCount; i++)
            {
                if (DeckModel.DeckReader[i].Cards.TryPop(out var card))
                {
                    var playerId = PlayerDictionaryModel.PlayerIds[i];
                    var playerCard = new PlayerCard(playerId, i, card);
                    cards[i] = playerCard;
                    HandCardModel.StoreNewCard(playerCard);
                }
            }

            return Option<PlayerCard[]>.Some(cards);
        }

        private IPlayerCountModel PlayerCountModel { get; }
        private IPlayerDictionaryModel PlayerDictionaryModel { get; }
        private IHandCardSettingModel HandCardSettingModel { get; }
        private IMutDeckModel DeckModel { get; }
        private IMutHandCardModel HandCardModel { get; }
    }
}