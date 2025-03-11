using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Adapter.IModel.InGame.Player
{
    public interface IIdInitializableMode
    {
        public void SetPlayerId(PlayerId playerId);
    }

    public interface IPlayerIdModel
    {
        public PlayerId PlayerId { get; }
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