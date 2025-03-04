using Utility.Structure.InGame;

namespace Adapter.IModel.InGame.Player
{
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