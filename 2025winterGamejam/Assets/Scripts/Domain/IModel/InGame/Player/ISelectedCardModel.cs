using Module.Option;
using R3;
using Structure.InGame;

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