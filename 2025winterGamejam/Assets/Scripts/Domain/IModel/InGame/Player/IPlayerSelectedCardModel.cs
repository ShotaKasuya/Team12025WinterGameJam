using R3;
using Utility.Module.Option;
using Utility.Structure.InGame;

namespace Domain.IModel.InGame.Player
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