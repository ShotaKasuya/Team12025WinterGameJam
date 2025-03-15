using Gambit.Unity.Adapter.IView.InGame.Ui;
using UnityEngine;
using UnityEngine.UI;

namespace Gambit.Unity.Adapter.View.InGame.Ui
{
    public class RemainCardView: MonoBehaviour, IRemainCardView
    {
        [SerializeField] private Text remainCardText;

        public void RemainCardCount(int cardCount)
        {
            remainCardText.text = cardCount.ToString();
        }
    }
}