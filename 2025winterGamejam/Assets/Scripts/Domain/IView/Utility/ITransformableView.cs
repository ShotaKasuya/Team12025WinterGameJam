using UnityEngine;

namespace Domain.IView.Utility
{
    public interface ITransformableView
    {
        public Transform ModelTransform { get; }
    }
}