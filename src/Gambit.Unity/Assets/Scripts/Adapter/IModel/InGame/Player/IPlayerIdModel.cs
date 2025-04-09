using System.Collections.Generic;
using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Adapter.IModel.InGame.Player
{
    public interface IIdInitializableModel
    {
        public void SetPlayerId(PlayerId playerId);
    }

    public interface IPlayerIdModel
    {
        public PlayerId LocalPlayerId { get; }
    }

    public interface IPlayerDictionaryModel
    {
        public IReadOnlyList<PlayerId> PlayerIds { get; }
    }

    public class MockPlayerIdModel : IPlayerIdModel
    {
        public PlayerId LocalPlayerId { set; get; } = new PlayerId();
        public int PlayerIndex { get; }

        public void SetUpId(PlayerId playerId)
        {
            LocalPlayerId = playerId;
        }
    }
}