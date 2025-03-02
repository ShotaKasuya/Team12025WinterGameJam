using System;
using System.Collections.Generic;
using UnityEngine;
using Utility.Module.Option;

namespace Utility.Structure.InGame
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

        private BattleResult(Option<PlayerId> winner, List<PlayerCard> userCards)
        {
            this.winner = winner;
            this.userCards = userCards;
        }
    }
}