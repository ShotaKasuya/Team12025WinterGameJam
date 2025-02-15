using UnityEngine;

namespace Domain.IView.InGame
{
    public interface ICardGeneratePointView
    {
        public Pose GeneratePoint { get; }
    }
}