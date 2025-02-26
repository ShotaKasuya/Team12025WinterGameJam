using System;
using System.Collections.Generic;
using Utility.Module.Option;
using Utility.Structure.InGame;

namespace Domain.IModel.InGame.Judgement
{
    public interface IMutSelectedCardModel
    {
        public void StorePlayerSelection(int playerId, Option<Card> selection);
    }
    
    public interface ISelectedCardModel
    {
        public Action<List<Card>> OnSelectCompleted { get; set; }
        public Option<Card>[] SelectedCards { get; }
    }
}