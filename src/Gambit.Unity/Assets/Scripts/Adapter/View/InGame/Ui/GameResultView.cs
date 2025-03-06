using Adapter.IView.InGame.Ui;
using UnityEngine;

namespace Adapter.View.InGame.Ui
{
    public class GameResultView : MonoBehaviour, IGameResultView
    {
        public void Enable(IGameResultView.Result result)
        {
            gameObject.SetActive(true);
        }
        
        public void DisEnable(IGameResultView.Result result)
        {
            gameObject.SetActive(false);
        }
    }
}