using System.Collections.Generic;
using Gambit.Unity.Adapter.IModel.InGame.Player;
using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Adapter.Model.InGame
{
    public class DebugPlayerIdModel : IIdInitializableModel, IPlayerIdModel, IPlayerDictionaryModel
    {
        public IReadOnlyList<PlayerId> PlayerIds => Players;
        public PlayerId LocalPlayerId => Players[0];
        public void SetPlayerId(PlayerId playerId)
        {
            Players[0] = playerId;
        }

        private PlayerId[] Players { get; } = new PlayerId[]
        {
            new (0), new (1)
        };
    }
}