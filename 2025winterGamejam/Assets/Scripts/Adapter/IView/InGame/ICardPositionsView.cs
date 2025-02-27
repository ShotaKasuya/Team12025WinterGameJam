using System.Collections.Generic;
using UnityEngine;

namespace Adapter.IView.InGame
{
    public interface ICardPositionsView
    {
        public IReadOnlyList<Pose> CardPositions { get; }
    }
}