using System.Collections.Generic;
using UnityEngine;

namespace Domain.IView.InGame
{
    public interface ICardPositionsView
    {
        public IReadOnlyList<Pose> CardPositions { get; }
    }
}