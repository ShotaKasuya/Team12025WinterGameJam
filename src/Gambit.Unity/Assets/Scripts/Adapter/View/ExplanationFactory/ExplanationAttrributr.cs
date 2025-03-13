using UnityEngine;

namespace Gambit.Unity.Adapter.View.ExplanationFactory
{
    public class ExplanationAttribute: PropertyAttribute
    {
        public System.Type ExplanationType { get; private set; }

        public ExplanationAttribute(System.Type explanationType)
        {
            ExplanationType = explanationType;
        }
    }
}