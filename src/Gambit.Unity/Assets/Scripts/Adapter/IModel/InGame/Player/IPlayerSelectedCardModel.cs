using Gambit.Unity.Utility.Module.Option;
using Gambit.Unity.Utility.Structure.InGame;
using R3;

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