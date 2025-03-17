using System.Collections.Generic;
using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Adapter.IModel.InGame.Judgement
{
    /// <summary>
    /// 各プレイヤーの手札
    /// </summary>
    public interface IMutHandCardModel : IHandCardModel
    {
        public void StoreNewCard(PlayerCard playerCard);
    }

    public interface IHandCardModel
    {
        public IReadOnlyList<HandCard> HandCardReader { get; }
    }

    public class MockHandCardModelModel : IHandCardModel
    {
        public IReadOnlyList<HandCard> HandCardReader { get; private set; } = new List<HandCard>();

        public void SetUpHandCard(List<HandCard> handCards)
        {
            HandCardReader = handCards;
        }
    }
}