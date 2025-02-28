using Cysharp.Threading.Tasks;
using Domain.IPresenter.InGame;
using Utility.Module.StateMachine;
using Utility.Structure.InGame.StateMachine;

namespace Domain.Flow.InGame
{
    /// <summary>
    /// 最初のステート
    /// </summary>
    public class InitStateFlow : StateBehaviour<GameStateType>
    {
        public InitStateFlow
        (
            IGameStartPresenter gameStartPresenter,
            IMutState<GameStateType> gameState
        ) : base(GameStateType.Init, gameState)
        {
            GameStartPresenter = gameStartPresenter;
        }

        public override void OnEnter(GameStateType prev)
        {
            var _ = StartFlow();
        }

        private async UniTask StartFlow()
        {
            await GameStartPresenter.GameStart();
            StateEntity.ChangeState(GameStateType.DecisionCard);
        }

        private IGameStartPresenter GameStartPresenter { get; }
    }
}