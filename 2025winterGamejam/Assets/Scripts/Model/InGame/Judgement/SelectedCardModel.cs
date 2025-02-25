using Domain.IModel.Global;
using Domain.IModel.InGame.Judgement;
using Utility.Module.Option;
using Utility.Structure.InGame;

namespace Model.InGame.Judgement
{
    public class SelectedCardModel: IMutSelectedCardModel, ISelectedCardModel
    {
        public SelectedCardModel(IPlayerCountModel playerCountModel)
        {
            SelectedCards = new Option<Card>[playerCountModel.PlayerCount];
        }
        
        public void StorePlayerSelection(int playerId, Option<Card> selection)
        {
            SelectedCards[playerId] = selection;
        }

        public Option<Card>[] SelectedCards { get; }
    }
}