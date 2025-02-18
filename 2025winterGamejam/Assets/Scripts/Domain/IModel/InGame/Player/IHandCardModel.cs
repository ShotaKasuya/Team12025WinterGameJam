using ObservableCollections;
using Structure.InGame;

namespace Domain.IModel.InGame.Player
{
    public interface IHandCardModel
    {
        public ObservableList<Card> HandCards { get; }
    }
}