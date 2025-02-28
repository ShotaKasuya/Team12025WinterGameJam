using System.Linq;
using Adapter.IModel.InGame.Judgement;
using Domain.IUseCase.InGame;

namespace Domain.UseCase.InGame
{
    public class IsReadyJudgeCase: IIsReadyJudgeCase
    {
        public IsReadyJudgeCase
        (
            ISelectedCardModel selectedCardModel
        )
        {
            SelectedCardModel = selectedCardModel;
        }

        public bool IsReady => SelectedCardModel.SelectedCards.All(x => x.IsSome);
        
        private ISelectedCardModel SelectedCardModel { get; }
    }
}