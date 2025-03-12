using Gambit.Unity.Adapter.IModel.InGame.Player;
using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Adapter.Model.InGame
{
    public class PlayerIdModel : IIdInitializableModel, IPlayerIdModel, IPlayerIndexModel
    {
        public PlayerId PlayerId { get; private set; }
        public PlayerId PlayerIndex { get; private set; }
        public void SetPlayerId(PlayerId playerId, PlayerId playerIndex)
        {
            PlayerId = playerId;
            PlayerIndex = playerIndex;
        }
    }
}