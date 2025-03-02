using System.Linq;
using Adapter.IModel.InGame.Judgement;
using Domain.IUseCase.InGame;

namespace Domain.UseCase.InGame
{
    public class IsGameEndCase: IIsGameEndCase
    {
        public IsGameEndCase
        (
            IHandCardModel handCardModel
        )
        {
            HandCardModel = handCardModel;
        }

        public bool IsGameEnded => HandCardModel.HandCardReader.First().Cards.Count == 0;
        
        private IHandCardModel HandCardModel { get; }
    }
}