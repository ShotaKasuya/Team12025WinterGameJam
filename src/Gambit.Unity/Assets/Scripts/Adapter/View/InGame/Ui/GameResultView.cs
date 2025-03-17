using Gambit.Unity.Adapter.IView.InGame.Ui;
using Gambit.Unity.Utility.Structure.InGame;
using UnityEngine;

namespace Gambit.Unity.Adapter.View.InGame.Ui
{
    public class GameResultView : MonoBehaviour, IGameResultView
    {
        [SerializeField] SpriteRenderer spriteRenderer;
        [SerializeField] private Sprite Win;
        [SerializeField] private Sprite lose;
        [SerializeField] private Sprite draw;

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