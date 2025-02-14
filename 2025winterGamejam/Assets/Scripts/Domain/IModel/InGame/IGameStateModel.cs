using System;

namespace Domain.IModel.InGame
{
    public interface IGameStartEventModel
    {
        Action GameStartEvent{get;set;}
    }

    public interface IDrawCardEventModel
    {
        Action GameDrawCardEvent{get;set;}
    }
}