using Adapter.IView.InGame.Ui;
using UnityEngine;
using Utility.Structure.InGame;

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
        
        public void Enable(Result result)
        {
            switch (result)
            {
                case Result.Win:
                    spriteRenderer.sprite = Win;
                    break;
                case Result.Lose:
                    spriteRenderer.sprite = lose;
                    break;
                case Result.Draw:
                    spriteRenderer.sprite = draw;
                    break;
            }
            gameObject.SetActive(true);
        }
        
        public void DisEnable()
        {
            gameObject.SetActive(false);
        }
    }
}