using System;
using Gambit.Unity.Adapter.IView.OutGame.Title;
using UnityEngine;
using UnityEngine.UI;

namespace Gambit.Unity.Adapter.View.OutGame.Title
{
    public class MatchConfPanelView : MonoBehaviour, IMatchConfPanelView
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button returnButton;

        public Action OnStartGame { get; set; }
        public Action OnReturn { get; set; }

        private void Awake()
        {
            startButton.onClick.AddListener(() => OnStartGame?.Invoke());
            returnButton.onClick.AddListener(() => OnReturn?.Invoke());
        }
    }
}