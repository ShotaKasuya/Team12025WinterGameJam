using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Domain.IUseCase.InGame
{
    public interface IIsReadyJudgeCase
    {
        public bool IsReady { get; }
        public PlayerCard[] SelectedCards { get; }
    }
}