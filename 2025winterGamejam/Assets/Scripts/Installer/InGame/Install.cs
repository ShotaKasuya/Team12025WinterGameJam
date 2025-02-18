using Model.InGame;
using Model.InGame.Player;
using UnityEngine;
using Utility.Structure.InGame;

namespace Installer.InGame
{
    public class Install: MonoBehaviour
    {
        [SerializeField] private PlayerInstaller playerInstaller;
        private void Awake()
        {
            var instance =  Instantiate(playerInstaller);
            instance.GameStateModel = new GameStateModel();
            instance.PlayerIdModel = new PlayerIdModel(new PlayerId(0));
        }
    }
}