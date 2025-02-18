using System.Collections.Generic;
using UnityEngine;

namespace IView.InGame
{
    public interface ICardPositionsView
    {
        public IReadOnlyList<Pose> CardPositions { get; }
    }
}