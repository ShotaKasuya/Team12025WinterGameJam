using Installer.InGame.Player;
using Model.InGame;
using Model.InGame.Player;
using UnityEngine;
using Utility.Structure.InGame;
using View.InGame;

namespace Installer.InGame
{
    public class Install: MonoBehaviour
    {
        [SerializeField] private PlayerInstaller playerInstaller;
        [SerializeField] private HandCardPositionsView cardPositionsView;
        
        private void Awake()
        {
            var instance =  Instantiate(playerInstaller);
            instance.GameStateModel = new GameStateModel();
            instance.PlayerIdModel = new PlayerIdModel(new PlayerId(0));
            instance.handCardPositionsView = cardPositionsView;
            Debug.Log("factory injected");
        }
    }
}