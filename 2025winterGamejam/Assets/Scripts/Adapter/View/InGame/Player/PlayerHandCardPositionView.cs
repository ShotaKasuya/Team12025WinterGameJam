using System.Collections.Generic;
using Adapter.IView.InGame;
using UnityEngine;
using Utility.Structure.InGame;

namespace Adapter.View.InGame.Player
{
    public class PlayerHandCardPositionView: ICardPositionsView
    {
        public PlayerHandCardPositionView(PlayerId playerId, List<ICardPositionsView> cardPositionsViews)
        {
            CardPositions = cardPositionsViews[playerId.Id].CardPositions;
        }
        public IReadOnlyList<Pose> CardPositions { get; }
    }
}