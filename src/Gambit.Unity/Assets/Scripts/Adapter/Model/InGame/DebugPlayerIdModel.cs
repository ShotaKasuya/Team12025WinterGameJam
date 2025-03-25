using System.Collections.Generic;
using Gambit.Unity.Adapter.IModel.InGame.Player;
using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Adapter.Model.InGame
{
    public class DebugPlayerIdModel : IIdInitializableModel, IPlayerIdModel, IPlayerDictionaryModel
    {
        public IReadOnlyList<PlayerId> PlayerIds => Players;
        public PlayerId PlayerId => Players[0];

        public void SetPlayerId(PlayerId playerId, int playerIndex)
        {
            Players[playerIndex] = playerId;
        }

        private PlayerId[] Players { get; } = new PlayerId[2]
        {
            new PlayerId(0), new PlayerId(1)
        };
    }
}