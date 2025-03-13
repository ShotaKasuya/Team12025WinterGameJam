using Cysharp.Threading.Tasks;
using Gambit.Unity.Domain.IPresenter.InGame;
using Gambit.Unity.Domain.IUseCase.InGame;
using Gambit.Unity.Module.Utility.Module.StateMachine;
using Gambit.Unity.Structure.Utility.InGame.StateMachine;

namespace Gambit.Unity.Domain.Flow.InGame
{
    /// <summary>
    /// 最初のステート
    /// </summary>
    public class InitStateFlow : StateBehaviour<GameStateType>
    {
        public InitStateFlow
        (
            IGameStartPresenter gameStartPresenter,
            IInitHandPresenter initHandPresenter,
            IDeckInitCase deckHandCardInitialize,
            IInitHandCardCase initHandCardCase,
            IMutState<GameStateType> gameState
        ) : base(GameStateType.Init, gameState)
        {
            GameStartPresenter = gameStartPresenter;
            InitHandPresenter = initHandPresenter;
            DeckHandCardInitialize = deckHandCardInitialize;
            InitHandCardCase = initHandCardCase;
        }

        public override void OnEnter(GameStateType prev)
        {
            var _ = StartFlow();
        }

        private async UniTask StartFlow()
        {
            await GameStartPresenter.GameStart();
            DeckHandCardInitialize.DeckInitialize();

            var initHandCard = InitHandCardCase.InitHand();
            await InitHandPresenter.PresentInitHand(initHandCard);
            
            StateEntity.ChangeState(GameStateType.DecisionCard);
        }

        private IGameStartPresenter GameStartPresenter { get; }
        private IInitHandPresenter InitHandPresenter { get; }
        private IDeckInitCase DeckHandCardInitialize { get; }
        private IInitHandCardCase InitHandCardCase { get; }
    }
}