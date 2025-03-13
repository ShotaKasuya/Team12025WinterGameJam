using System.Collections.Generic;
using Gambit.Unity.Adapter.IModel.InGame.Player;
using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Adapter.Model.InGame
{
    public class PlayerIdModel : IIdInitializableModel, IPlayerIdModel, IPlayerDictionaryModel
    {
        public IReadOnlyList<PlayerId> PlayerIds => Players;
        public PlayerId PlayerId { get; private set; }
        public int PlayerIndex { get; private set; }
        public void SetPlayerId(PlayerId playerId, int playerIndex)
        {
            Players[playerIndex] = playerId;
            PlayerId = playerId;
            PlayerIndex = playerIndex;
        }

        private PlayerId[] Players { get; } = new PlayerId[2];
    }
}