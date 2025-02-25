using System.Collections.Generic;
using Domain.IView.InGame;
using UnityEngine;
using Utility.Structure.InGame;

namespace View.InGame.Player
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