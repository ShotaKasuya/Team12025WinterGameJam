using Adapter.IModel.InGame;
using Adapter.IModel.InGame.Judgement;
using Adapter.IModel.InGame.Player;
using Adapter.IView.InGame.Ui;
using Utility.Structure.InGame;
using VContainer.Unity;

namespace Adapter.Linker.InGame
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