using Gambit.Unity.Adapter.IModel.InGame;
using Gambit.Unity.Adapter.IModel.InGame.Judgement;
using Gambit.Unity.Adapter.IModel.InGame.Player;
using Gambit.Unity.Adapter.IView.InGame.Ui;
using VContainer.Unity;

namespace Gambit.Unity.Adapter.ILinker.InGame
{
    public class DescriptionLinker : ITickable
    {
        public DescriptionLinker
        (
            IPlayerIdModel playerIdModel,
            ISelectedCardModel selectedCardModel,
            ICardDescriptionModel cardDescriptionModel,
            ICardDescriptionView cardDescriptionView
        )
        {
            PlayerIdModel = playerIdModel;
            SelectedCardModel = selectedCardModel;
            CardDescriptionModel = cardDescriptionModel;
            CardDescriptionView = cardDescriptionView;
        }

        public void Tick()
        {
            var selectedCard = SelectedCardModel.GetSelection(PlayerIdModel.PlayerId);
            
            if (selectedCard.TryGetValue(out var card))
            {
                var description = CardDescriptionModel.Description(card.Card);
                
                CardDescriptionView.SetDescription(description);
            }
        }

        private IPlayerIdModel PlayerIdModel { get; }
        private ISelectedCardModel SelectedCardModel { get; }
        private ICardDescriptionModel CardDescriptionModel { get; }
        private ICardDescriptionView CardDescriptionView { get; }
    }
}