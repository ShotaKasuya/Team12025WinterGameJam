using Gambit.Unity.Adapter.IModel.Global;
using Gambit.Unity.Adapter.IModel.InGame.Judgement;
using Gambit.Unity.Utility.Module.Option;
using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Adapter.Model.InGame.Judgement
{
    public class SelectedCardModel : IMutSelectedCardModel
    {
        public SelectedCardModel(IPlayerCountModel playerCountModel)
        {
            SelectedCards = new Option<PlayerCard>[playerCountModel.PlayerCount];
        }

        public Option<PlayerCard> GetSelection(PlayerId playerId)
        {
            return SelectedCards[playerId.Id];
        }

        public void StorePlayerSelection(PlayerId playerId, Option<PlayerCard> selection)
        {
            SelectedCards[playerId.Id] = selection;
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