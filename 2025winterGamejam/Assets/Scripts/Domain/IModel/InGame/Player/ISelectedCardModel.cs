using R3;
using Utility.Module.Option;
using Utility.Structure.InGame;

namespace Domain.IModel.InGame.Player
{
    public interface IMutSelectedCardModel
    {
        public ReactiveProperty<Option<Card>> SelectedCard { get; }
    }

    public interface ISelectedCardModel
    {
        public ReadOnlyReactiveProperty<Option<PlayerHandCard>> OnSelected { get; }
    }
}