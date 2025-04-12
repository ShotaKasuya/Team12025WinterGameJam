using Gambit.Unity.Adapter.IView.InGame.Ui;
using Gambit.Unity.Utility.Structure.InGame;
using UnityEngine;
using UnityEngine.UI;

namespace Gambit.Unity.Adapter.View.InGame.Ui
{
    public class ScoreView: MonoBehaviour, IScoreView
    {
        [SerializeField] private Text[] scoreText;

        public void SetScore(PlayerId playerId, int score)
        {
            scoreText[playerId.Id].text = score.ToString();
        }
    }
}