using System.Collections.Generic;
using Utility.Module.Option;

namespace Utility.Structure.InGame
{
    public readonly struct BattleResult
    {
        public static BattleResult Result(PlayerId winner, List<Card> userCards)
        {
            return new BattleResult(Option<PlayerId>.Some(winner), userCards);
        }

        public static BattleResult Draw(List<Card> userCards)
        {
            return new BattleResult(Option<PlayerId>.None(), userCards);
        }
        
        public Option<PlayerId> Winner { get; }
        public IReadOnlyList<Card> Cards => UserCards;
        private List<Card> UserCards { get; }

        private BattleResult(Option<PlayerId> winner, List<Card> userCards)
        {
            Winner = winner;
            UserCards = userCards;
        }
    }
}