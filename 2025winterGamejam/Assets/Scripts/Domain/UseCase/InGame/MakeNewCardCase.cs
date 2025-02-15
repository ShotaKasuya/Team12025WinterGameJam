using Domain.IAdaptor.Factory;
using Domain.IModel.InGame;
using Domain.IView.InGame;
using Structure.InGame;

namespace Domain.UseCase.InGame
{
    public class MakeNewCardCase
    {
        public MakeNewCardCase
        (
            IHandCardEventModel handCardEventModel,
            ICardFactory cardFactory,
            ICardGeneratePointView generatePointView
        )
        {
            HandCardEventModel = handCardEventModel;
            CardFactory = cardFactory;
            GeneratePointView = generatePointView;

            HandCardEventModel.AddNewCardEvent += MakeCard;
        }

        private void MakeCard(PlayerHandCard playerHandCard)
        {
            var card = CardFactory.BuildCard(playerHandCard);
            card.transform.position = GeneratePointView.GeneratePoint.position;
        }

        private IHandCardEventModel HandCardEventModel { get; }
        private ICardFactory CardFactory { get; }
        private ICardGeneratePointView GeneratePointView { get; }
    }
}