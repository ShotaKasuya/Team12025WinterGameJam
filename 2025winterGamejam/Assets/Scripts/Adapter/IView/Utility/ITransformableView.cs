using UnityEngine;

namespace Adapter.IView.Utility
{
    public interface ITransformableView
    {
        public Transform ModelTransform { get; }
    }
}