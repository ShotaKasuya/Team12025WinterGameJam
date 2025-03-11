using Gambit.Unity.Structure.Utility.InGame;
using UnityEngine;
using UnityEngine.UI;

namespace Gambit.Unity.Adapter.IView.InGame.IExplanationFactory
{
    public interface IExplanationSprites
    {
        public Image GetImage(Card  card);
    }
}