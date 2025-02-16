using System.Collections.Generic;
using Module.Option;

namespace Structure.InGame
{
    public readonly struct BattleResult
    {
        public static BattleResult Result(int winner, List<Card> userCards)
        {
            return new BattleResult(Option<int>.Some(winner), userCards);
        }

        public static BattleResult Draw(List<Card> userCards)
        {
            return new BattleResult(Option<int>.None(), userCards);
        }
        
        public Option<int> Winner { get; }
        public IReadOnlyList<Card> Cards => UserCards;
        private List<Card> UserCards { get; }

        private BattleResult(Option<int> winner, List<Card> userCards)
        {
            Winner = winner;
            UserCards = userCards;
        }
    }
}