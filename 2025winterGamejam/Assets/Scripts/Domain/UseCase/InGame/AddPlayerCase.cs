using Domain.IModel.Global;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Domain.UseCase.InGame
{
    public class AddPlayerCase: IStartable
    {
        public AddPlayerCase
        (
            IPlayerCountModel playerCountModel,
            IObjectResolver container,
            MonoBehaviour playerInstaller
        )
        {
            PlayerCountModel = playerCountModel;
            Container = container;
            PlayerInstaller = playerInstaller;
        }
        
        public void Start()
        {
            for (int i = 0; i < PlayerCountModel.PlayerCount; i++)
            {
                Container.Instantiate(PlayerInstaller);
            }
        }
        
        private IPlayerCountModel PlayerCountModel { get; }
        private IObjectResolver Container { get; } 
        private MonoBehaviour PlayerInstaller { get; }
    }
}