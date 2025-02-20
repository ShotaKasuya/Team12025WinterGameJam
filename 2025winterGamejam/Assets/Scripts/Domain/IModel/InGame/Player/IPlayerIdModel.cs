using Utility.Structure.InGame;

namespace Domain.IModel.InGame.Player
{
    public interface IPlayerIdModel
    {
        public PlayerId PlayerId { get; }
    }
    public class MockPlayerModel : IPlayerIdModel
    {
        public PlayerId PlayerId { set; get; } = new PlayerId();

        public void StorePlayerId(PlayerId playerId)
        {
            PlayerId = playerId;
        }
    }
    
}