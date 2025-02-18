using R3;
using Utility.Module.Option;
using Utility.Structure.InGame;

namespace Domain.IPresenter.InGame.Player
{
    public interface IHandCardEventPresenter
    {
        public ReadOnlyReactiveProperty<Option<Card>> OnSelectCard { get; }
    }

    public interface IHandCardPresenter
    {
        public void ShowNewCard(Card card);
        public void DeleteCard(Card card);
    }
}