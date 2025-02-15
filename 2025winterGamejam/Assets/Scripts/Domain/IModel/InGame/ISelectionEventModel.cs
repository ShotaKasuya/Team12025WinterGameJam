using System;
using System.Collections.Generic;
using Module.Option;
using Structure.InGame;

namespace Domain.IModel.InGame
{
    public interface ISelectedCardModel
    {
        public void StorePlayerSelection(int playerId, Option<Card> selection);
    }
    
    public interface ISelectionEventModel
    {
        public Action<List<Card>> OnAllPlayerSelectedCard { get; set; }
    }
}