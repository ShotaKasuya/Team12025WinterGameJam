using Utility.Module.Option;
using Utility.Structure.InGame;

namespace Adapter.IModel.InGame.Judgement
{
    public interface IMutSelectedCardModel: ISelectedCardModel
    {
        public void StorePlayerSelection(int playerId, Option<PlayerCard> selection);
    }
    
    public interface ISelectedCardModel
    {
        public Option<PlayerCard>[] SelectedCards { get; }
        public Option<PlayerCard> GetSelection(PlayerId playerId);

        public void Clear();
    }
}