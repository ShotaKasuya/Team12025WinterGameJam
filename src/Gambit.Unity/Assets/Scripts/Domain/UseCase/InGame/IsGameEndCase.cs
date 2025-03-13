using System.Linq;
using Gambit.Unity.Adapter.IModel.InGame.Judgement;
using Gambit.Unity.Domain.IUseCase.InGame;

namespace Gambit.Unity.Domain.UseCase.InGame
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