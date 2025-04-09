using Gambit.Unity.Utility.Module.Option;
using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Adapter.IModel.InGame.Judgement
{
    public interface IMutSelectedCardModel : ISelectedCardModel
    {
        public void StorePlayerSelection(PlayerId playerId, Option<PlayerCard> selection);
    }

    public interface ISelectedCardModel
    {
        public Option<PlayerCard>[] SelectedCards { get; }
        public Option<PlayerCard> GetSelection(PlayerId playerId);

        public void Clear();
    }

    public class MockSelectedCardModel : ISelectedCardModel
    {
        public MockSelectedCardModel(int playerCount)
        {
            SelectedCards = new Option<PlayerCard> [playerCount];
        }

        public Option<PlayerCard>[] SelectedCards { get; }

        public void SetCards(PlayerCard[] cards)
        {
            for (int i = 0; i < SelectedCards.Length; i++)
            {
                SelectedCards[i] = Option<PlayerCard>.Some(cards[i]);
            }
        }

        public Option<PlayerCard> GetSelection(PlayerId playerId)
        {
            return SelectedCards[playerId.Id];
        }

        public void Clear()
        {
            for (var i = 0; i < SelectedCards.Length; i++)
            {
                SelectedCards[i] = Option<PlayerCard>.None();
            }
        }
    }
}