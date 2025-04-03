using System;
using System.Collections.Generic;
using Gambit.Unity.Utility.Module.Option;
using UnityEngine;

namespace Gambit.Unity.Utility.Structure.InGame
{
    [Serializable]
    public struct BattleResult
    {
        [SerializeField] private Option<PlayerId> winner;
        [SerializeField] private List<PlayerCard> userCards;
        public static BattleResult Result(PlayerId winner, List<PlayerCard> userCards)
        {
            return new BattleResult(Option<PlayerId>.Some(winner), userCards);
        }

        public static BattleResult Draw(List<PlayerCard> userCards)
        {
            return new BattleResult(Option<PlayerId>.None(), userCards);
        }

        public Option<PlayerId> Winner => winner;
        public IReadOnlyList<PlayerCard> Cards => userCards;

        public bool IsResult(out PlayerId winnerId)
        {
            if (winner.TryGetValue(out PlayerId value))
            {
                winnerId = value;
                return true;
            }

            winnerId = default;
            return false;
        }

        public bool IsDraw() => Winner.IsNone;

        private BattleResult(Option<PlayerId> winner, List<PlayerCard> userCards)
        {
            this.winner = winner;
            this.userCards = userCards;
        }

        public override string ToString()
        {
            var cards = "[\n";
            foreach (var playerCard in userCards)
            {
                cards += playerCard;
            }

            cards += "]";
            return "BattleResult (\n" +
                   $"{winner}" +
                   $"{cards}" +
                   ")";
        }
    }
}