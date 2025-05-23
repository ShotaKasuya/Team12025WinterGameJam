using System.Collections.Generic;
using Gambit.Unity.Adapter.IModel.Global;
using Gambit.Unity.Adapter.IModel.InGame.Judgement;
using Gambit.Unity.Adapter.IModel.InGame.Setting;
using Gambit.Unity.Domain.IUseCase.InGame;
using Gambit.Unity.Utility.Module.Option;
using Gambit.Unity.Utility.Structure.InGame;

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
            if (!DeckModel.IsRemain)
            {
                return Option<PlayerCard[]>.None();
            }
            
            var buffer = new PlayerCard[PlayerCountModel.PlayerCount];
            DeckModel.DrawCards(buffer);
            foreach (var playerCard in buffer)
            {
                HandCardModel.StoreNewCard(playerCard);
            }

            return Option<PlayerCard[]>.Some(buffer);
        }

        private IPlayerCountModel PlayerCountModel { get; }
        private IHandCardSettingModel HandCardSettingModel { get; }
        private IMutDeckModel DeckModel { get; }
        private IMutHandCardModel HandCardModel { get; }
    }
}