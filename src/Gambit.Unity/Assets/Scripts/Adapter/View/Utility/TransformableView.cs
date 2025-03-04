using Adapter.IView.Utility;
using UnityEngine;

namespace Adapter.View.Utility
{
    public class TransformableView : MonoBehaviour, ITransformableView
    {
        public Transform ModelTransform { get; private set; }

        private void Awake()
        {
            ModelTransform = transform;
        }
    }
}