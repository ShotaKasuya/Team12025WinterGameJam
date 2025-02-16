using System.Collections.Generic;
using UnityEngine;

namespace IView.InGame
{
    public interface ICardPositionView
    {
        public IReadOnlyList<Pose> CardPositions { get; }
    }
}