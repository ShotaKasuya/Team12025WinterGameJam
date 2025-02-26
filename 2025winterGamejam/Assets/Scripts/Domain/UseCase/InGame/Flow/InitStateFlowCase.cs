using Domain.IModel.InGame;
using Utility.Structure.InGame;
using VContainer.Unity;

namespace Domain.UseCase.InGame.Flow
{
    public class InitStateFlowCase: IStartable
    {
        public InitStateFlowCase
        (
            IMutGameStateModel gameStateModel
        )
        {
            GameStateModel = gameStateModel;
        }

        public void Initialize()
        {
        }
        public void Start()
        {
            // todo: 演出
            
            GameStateModel.SetGameState(GameStateType.DecisionCard);
        }
        
        private IMutGameStateModel GameStateModel { get; }
    }
}