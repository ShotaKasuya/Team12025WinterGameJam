using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Adapter.IModel.InGame.Player
{
    public interface IIdInitializableModel
    {
        public void SetPlayerId(PlayerId playerId, PlayerId playerIndex);
    }

    public interface IPlayerIdModel
    {
        public PlayerId PlayerId { get; }
    }

    public interface IPlayerIndexModel
    {
        public PlayerId PlayerIndex { get; }
    }

    public class MockPlayerIdModel : IPlayerIdModel
    {
        public PlayerId PlayerId { set; get; } = new PlayerId();

        public void SetUpId(PlayerId playerId)
        {
            PlayerId = playerId;
        }
    }
}