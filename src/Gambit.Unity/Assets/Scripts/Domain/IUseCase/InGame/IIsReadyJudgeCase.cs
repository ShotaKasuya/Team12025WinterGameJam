using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Domain.IUseCase.InGame
{
    public interface IIsReadyJudgeCase
    {
        public bool IsReady { get; }
        public PlayerCard[] SelectedCards { get; }
    }
}