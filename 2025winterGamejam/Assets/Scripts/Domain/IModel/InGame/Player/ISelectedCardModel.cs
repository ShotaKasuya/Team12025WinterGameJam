using R3;
using Structure.InGame;

namespace Domain.IModel.InGame.Player
{
    public interface IMutSelectedCardModel
    {
        public ReactiveProperty<Card> SelectedCard { get; }
    }
    
    public interface ISelectedCardModel
    {
        public ReadOnlyReactiveProperty<PlayerHandCard> OnSelected { get; }
    }
}