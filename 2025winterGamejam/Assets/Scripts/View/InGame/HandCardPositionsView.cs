using System.Collections.Generic;
using System.Linq;
using IView.InGame;
using UnityEngine;

namespace View.InGame
{
    public class HandCardPositionsView: MonoBehaviour, ICardPositionsView
    {
        [SerializeField] private List<Transform> cardPositions;

        public IReadOnlyList<Pose> CardPositions =>
            cardPositions.Select(x => new Pose(x.position, x.rotation)).ToList();
    }
}