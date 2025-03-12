using Cysharp.Threading.Tasks;
using Gambit.Unity.Adapter.IView.InGame.Ui;
using Gambit.Unity.Adapter.View.ExplanationFactory;
using Gambit.Unity.Structure.Utility.InGame;
using UnityEngine;
using UnityEngine.UI;

namespace Gambit.Unity.Adapter.View.InGame.Ui
{
    [RequireComponent(typeof(Image))]
    public class ExplanationImageView:MonoBehaviour,IExplanationImageView
    {
            public Image Image { get; private set; }
            public float FadeInDuration => fadeInDuration;
            public float FadeOutDuration => fadeOutDuration;
            public PlayerCard Card { get; private set; }

            private Sprite sprite => explanationSprites.GetImage(Card.Card);
            private SpriteRenderer spriteRenderer;
            [SerializeField] private float fadeInDuration;
            [SerializeField] private float fadeOutDuration;
            [SerializeField] private ExplanationSprites  explanationSprites;


            // public void Inject(PlayerCard playercard)
            // {
            //     
            // }
            
            private void Awake()
            {
                Image = GetComponent<Image>();
            }

            public void Face()
            {
                spriteRenderer.sprite = sprite;
            }
    }
}