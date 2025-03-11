using Adapter.IView.InGame.Ui;
using UnityEngine;

namespace Adapter.View.InGame.Ui
{
    public class GameResultView : MonoBehaviour, IGameResultView
    {
        [SerializeField] SpriteRenderer spriteRenderer;
        [SerializeField] private Sprite Win;
        [SerializeField] private Sprite lose;
        [SerializeField] private Sprite draw;

        public GameResultView()
        {
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }
        
        public void Enable(IGameResultView.Result result)
        {
            switch (result)
            {
                case IGameResultView.Result.Win:
                    spriteRenderer.sprite = Win;
                    break;
                case IGameResultView.Result.Lose:
                    spriteRenderer.sprite = lose;
                    break;
                case IGameResultView.Result.Draw:
                    spriteRenderer.sprite = draw;
                    break;
            }
            gameObject.SetActive(true);
        }
        
        public void DisEnable(IGameResultView.Result result)
        {
            gameObject.SetActive(false);
        }
    }
}