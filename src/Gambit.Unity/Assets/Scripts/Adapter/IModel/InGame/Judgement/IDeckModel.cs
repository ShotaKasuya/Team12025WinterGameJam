using System;
using System.Collections.Generic;
using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Adapter.IModel.InGame.Judgement
{
    /// <summary>
    /// 各プレイヤーのデッキ
    /// </summary>
    public interface IMutDeckModel: IDeckModel
    {
        public Deck[] Decks { get; }
        public void DrawCards(PlayerCard[] buffer);
    }
    
    public interface IDeckModel
    {
        public IReadOnlyList<Deck> DeckReader { get; }
        public bool IsRemain { get; }
    }

    public interface IDeckChangeEventModel
    {
        /// <summary>
        /// デッキの中身が変化したイベント
        /// `int` : デッキの残りカード数
        /// </summary>
        public Action<Context> OnChange { get; set; }
        public readonly struct Context
        {
            public PlayerId PlayerId { get; }
            public int RemainCardCount { get; }

            public Context(PlayerId playerId, int remainCardCount)
            {
                PlayerId = playerId;
                RemainCardCount = remainCardCount;
            }
        }
    }

    public class MockDeckModel : IMutDeckModel
    {
        public Deck[] Decks { get; private set; }

        public bool IsRemain => DeckReader[0].Cards.Count == 0;
        public IReadOnlyList<Deck> DeckReader => Decks;

        public void DrawCards(PlayerCard[] buffer)
        {
            throw new System.NotImplementedException();
        }
    }
}