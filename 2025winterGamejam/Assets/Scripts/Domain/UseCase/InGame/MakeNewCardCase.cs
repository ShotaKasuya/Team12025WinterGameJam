using Domain.IAdapter.InGame;
using Domain.IModel.InGame;
using Structure.InGame;

namespace Domain.UseCase.InGame
{
    public class MakeNewCardCase
    {
        public MakeNewCardCase
        (
            IHandCardEventModel handCardEventModel,
            ICardFactory cardFactory
        )
        {
            HandCardEventModel = handCardEventModel;
            CardFactory = cardFactory;

            HandCardEventModel.AddNewCardEvent += MakeCard;
        }

        private void MakeCard(PlayerHandCard playerHandCard)
        {
            CardFactory.BuildCard(playerHandCard);
        }

        private IHandCardEventModel HandCardEventModel { get; }
        private ICardFactory CardFactory { get; }
    }
}