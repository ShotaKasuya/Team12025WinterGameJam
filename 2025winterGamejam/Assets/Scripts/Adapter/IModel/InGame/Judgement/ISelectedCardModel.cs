using System;
using System.Collections.Generic;
using Utility.Module.Option;
using Utility.Structure.InGame;

namespace Adapter.IModel.InGame.Judgement
{
    public interface IMutSelectedCardModel
    {
        public void StorePlayerSelection(int playerId, Option<PlayerCard> selection);
    }
    
    public interface ISelectedCardModel
    {
        public Action<List<PlayerCard>> OnSelectCompleted { get; set; }
        public Option<PlayerCard>[] SelectedCards { get; }

        public void Clear();
    }
}