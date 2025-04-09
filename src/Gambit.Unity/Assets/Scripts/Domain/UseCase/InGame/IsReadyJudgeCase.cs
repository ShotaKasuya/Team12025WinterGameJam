using System.Linq;
using Gambit.Unity.Adapter.IModel.InGame.Judgement;
using Gambit.Unity.Domain.IUseCase.InGame;
using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Domain.UseCase.InGame
{
    public class IsReadyJudgeCase : IIsReadyJudgeCase
    {
        public IsReadyJudgeCase
        (
            ISelectedCardModel selectedCardModel
        )
        {
            SelectedCardModel = selectedCardModel;
        }

        public bool IsReady => SelectedCardModel
            .SelectedCards.All(x => x.IsSome);

        public PlayerCard[] SelectedCards => SelectedCardModel
            .SelectedCards.Select(x => x.Unwrap()).ToArray();

        private ISelectedCardModel SelectedCardModel { get; }
    }
}