using System.Collections.Generic;
using Utility.Module.Option;

namespace Utility.Structure.InGame
{
    public readonly struct BattleResult
    {
        public static BattleResult Result(PlayerId winner, List<PlayerCard> userCards)
        {
            return new BattleResult(Option<PlayerId>.Some(winner), userCards);
        }

        public static BattleResult Draw(List<PlayerCard> userCards)
        {
            return new BattleResult(Option<PlayerId>.None(), userCards);
        }
        
        public Option<PlayerId> Winner { get; }
        public IReadOnlyList<PlayerCard> Cards => UserCards;
        private List<PlayerCard> UserCards { get; }

        private BattleResult(Option<PlayerId> winner, List<PlayerCard> userCards)
        {
            Winner = winner;
            UserCards = userCards;
        }
    }
}