using Gambit.Unity.Utility.Module.Option;
using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Adapter.IModel.InGame.Judgement
{
    public interface IMutSelectedCardModel: ISelectedCardModel
    {
        public void StorePlayerSelection(int playerId, Option<PlayerCard> selection);
    }
    
    public interface ISelectedCardModel
    {
        public Option<PlayerCard>[] SelectedCards { get; }
        public Option<PlayerCard> GetSelection(int playerId);

        public void Clear();
    }
}