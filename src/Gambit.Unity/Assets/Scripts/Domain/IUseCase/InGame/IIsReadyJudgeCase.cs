using Utility.Structure.InGame;

namespace Domain.IUseCase.InGame
{
    public interface IIsReadyJudgeCase
    {
        public bool IsReady { get; }
        public PlayerCard[] SelectedCards { get; }
    }
}