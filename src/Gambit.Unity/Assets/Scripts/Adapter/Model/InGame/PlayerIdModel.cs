using System.Collections.Generic;
using Gambit.Unity.Adapter.IModel.InGame.Player;
using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Adapter.Model.InGame
{
    public class PlayerIdModel : IIdInitializableModel, IPlayerIdModel, IPlayerDictionaryModel
    {
        public IReadOnlyList<PlayerId> PlayerIds => Players;
        public PlayerId LocalPlayerId { get; private set; }
        public void SetPlayerId(PlayerId playerId)
        {
            LocalPlayerId = playerId;
        }

        private PlayerId[] Players { get; } = new PlayerId[2];
    }
}