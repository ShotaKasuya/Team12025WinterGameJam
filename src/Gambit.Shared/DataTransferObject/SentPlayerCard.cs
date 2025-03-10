namespace Gambit.Shared.DataTransferObject
{
        public struct SentPlayerCard
        {
            public SentPlayerCard(PlayerId playerId, Card card)
            {
                this.playerId = playerId;
                this.card = card;
            }

            private PlayerId playerId;
            private Card card;
            public PlayerId PlayerId => playerId;
            public Card Card => card;
            public RankTransObj Rank => Card.Rank;
            public SuitTransObj Suit => Card.Suit;
        }
}