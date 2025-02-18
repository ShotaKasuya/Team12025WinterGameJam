using System;
using Utility.Structure.InGame;

namespace Domain.IModel.InGame
{
    public interface IMutGameStateModel
    {
        public void SetGameState(GameStateType gameState);
    }
    public interface IGameStartEventModel
    {
        Action GameStartEvent { get; set; }
    }

    public interface IDrawCardEventModel
    {
        Action GameDrawCardEvent { get; set; }
    }
 


    public class MockStateEventModel : IGameStartEventModel, IDrawCardEventModel
    {
        public Action GameStartEvent { get; set; }
        public Action GameDrawCardEvent { get; set; }

        public void InvokeGameStart()
        {
            GameStartEvent?.Invoke();
        }

        public void InvokeDrawCard()
        {
            GameDrawCardEvent?.Invoke();
        }
    }
}