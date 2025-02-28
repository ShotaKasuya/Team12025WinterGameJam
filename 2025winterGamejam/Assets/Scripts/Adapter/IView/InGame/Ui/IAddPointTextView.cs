using Adapter.IView.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Adapter.IView.InGame.Ui
{
    public interface IAddPointTextView 
    {
        public Text  Text {get;}
        public float FadeInDuration {get;}
        public float FadeOutDuration{get;}
    }
}