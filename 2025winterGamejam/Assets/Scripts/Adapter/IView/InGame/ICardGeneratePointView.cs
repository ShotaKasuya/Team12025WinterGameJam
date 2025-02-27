using UnityEngine;

namespace Adapter.IView.InGame
{
    public interface ICardGeneratePointView
    {
        public Pose GeneratePoint { get; }
    }
}