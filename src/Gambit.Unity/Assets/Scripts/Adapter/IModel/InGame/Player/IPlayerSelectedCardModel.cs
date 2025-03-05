using Gambit.Unity.Structure.Utility.InGame;
using R3;
using Utility.Module.Option;

namespace Gambit.Unity.Adapter.IModel.InGame.Player
{
    public interface IMutPlayerSelectedCardModel: IPlayerSelectedCardModel
    {
        public void SetSelectedCard(Option<Card> card);
    }

    public interface IPlayerSelectedCardModel
    {
        public ReadOnlyReactiveProperty<Option<Card>> OnSelected { get; }
    }
}