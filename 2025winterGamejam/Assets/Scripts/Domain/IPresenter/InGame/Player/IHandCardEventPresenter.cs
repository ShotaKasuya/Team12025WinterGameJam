using Module.Option;
using R3;
using Structure.InGame;

namespace Domain.IPresenter.InGame.Player
{
    public interface IHandCardEventPresenter
    {
        public ReadOnlyReactiveProperty<Option<HandCardDesc>> OnSelectCard { get; set; }
    }

    public interface IHandCardPresenter
    {
        public void ShowNewCard(Card card);
        public void DeleteCard(Card card);
    }

    public struct HandCardDesc
    {
        public HandCardDesc
        (
            int id, Card card
        )
        {
            Card = card;
            Id = id;
        }

        public Card Card { get; }
        public int Id { get; }
    }
}