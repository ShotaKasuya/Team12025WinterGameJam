using Gambit.Unity.Adapter.IModel.Global;
using Gambit.Unity.Adapter.IModel.InGame.Judgement;
using Gambit.Unity.Module.Utility.Module.Option;
using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Adapter.Model.InGame.Judgement
{
    public class SelectedCardModel : IMutSelectedCardModel, ISelectedCardModel
    {
        public SelectedCardModel(IPlayerCountModel playerCountModel)
        {
            SelectedCards = new Option<PlayerCard>[playerCountModel.PlayerCount];
        }

        public void StorePlayerSelection(int playerId, Option<PlayerCard> selection)
        {
            SelectedCards[playerId] = selection;
        }

        public Option<PlayerCard> GetSelection(int index)
        {
            return SelectedCards[index];
        }

        public void Clear()
        {
            for (int i = 0; i < SelectedCards.Length; i++)
            {
                SelectedCards[i] = Option<PlayerCard>.None();
            }
        }

        public Option<PlayerCard>[] SelectedCards { get; }
    }
}