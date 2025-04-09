using Gambit.Unity.Adapter.IView.InGame.Ui;
using UnityEngine;
using UnityEngine.UI;

namespace Gambit.Unity.Adapter.View.InGame.Ui
{
    public class ScoreView: MonoBehaviour, IScoreView
    {
        [SerializeField] private Text scoreText;
        
        public void SetScore(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}