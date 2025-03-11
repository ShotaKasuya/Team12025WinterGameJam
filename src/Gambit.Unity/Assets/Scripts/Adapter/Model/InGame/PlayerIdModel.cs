using Gambit.Unity.Adapter.IModel.InGame.Player;
using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Adapter.Model.InGame
{
    public class PlayerIdModel : IIdInitializableMode, IPlayerIdModel
    {
        public PlayerIdModel(PlayerId playerId)
        {
            PlayerId = playerId;
        }

        public PlayerId PlayerId { get; private set; }
        public void SetPlayerId(PlayerId playerId)
        {
            PlayerId = playerId;
        }
    }
}