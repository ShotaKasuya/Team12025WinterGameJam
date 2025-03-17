using System.Collections.Generic;
using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Adapter.IModel.InGame.Player
{
    public interface IIdInitializableModel
    {
        public void SetPlayerId(PlayerId playerId, int playerIndex);
    }

    public interface IPlayerIdModel
    {
        public PlayerId PlayerId { get; }
        public int PlayerIndex { get; }
    }

    public interface IPlayerDictionaryModel
    {
        public IReadOnlyList<PlayerId> PlayerIds { get; }
    }

    public class MockPlayerIdModel : IPlayerIdModel
    {
        public PlayerId PlayerId { set; get; } = new PlayerId();
        public int PlayerIndex { get; }

        public void SetUpId(PlayerId playerId)
        {
            PlayerId = playerId;
        }
    }
}