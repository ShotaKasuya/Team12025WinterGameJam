using Adapter.IModel.InGame.Player;
using Utility.Structure.InGame;

namespace Adapter.Model.InGame
{
    public class PlayerIdModel : IPlayerIdModel
    {
        public PlayerIdModel(PlayerId playerId)
        {
            PlayerId = playerId;
        }

        public PlayerId PlayerId { get; }
    }
}