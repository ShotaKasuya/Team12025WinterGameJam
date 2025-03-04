using System.Linq;
using Adapter.IModel.InGame.Judgement;
using Domain.IUseCase.InGame;
using Utility.Structure.InGame;

namespace Domain.UseCase.InGame
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