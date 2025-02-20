using Model.InGame;
using Model.InGame.Player;
using UnityEngine;
using Utility.Structure.InGame;
using View.InGame;

namespace Installer.InGame.Player
{
    public class Install : MonoBehaviour
    {
        [SerializeField] private PlayerInstaller playerInstaller;
        [SerializeField] private HandCardPositionsView cardPositionsView;

        private void Awake()
        {
            var instance = Instantiate(playerInstaller);
            instance.Inject(new PlayerIdModel(new PlayerId(0)), new GameStateModel(), cardPositionsView);
            Debug.Log("factory injected");
        }
    }
}