using System;
using System.Collections.Generic;
using System.Linq;
using Adapter.IModel.Global;
using Adapter.IModel.InGame.Judgement;
using Utility.Module.Option;
using Utility.Structure.InGame;

namespace Adapter.Model.InGame.Judgement
{
    public class SelectedCardModel : IMutSelectedCardModel, ISelectedCardModel
    {
        public SelectedCardModel(IPlayerCountModel playerCountModel)
        {
            SelectedCards = new Option<PlayerCard>[playerCountModel.PlayerCount];
        }

        public void StorePlayerSelection(int playerId, Option<PlayerCard> selection)
        {
            SelectedCards[playerId] = selection;
            if (SelectedCards.All(x => x.IsSome))
            {
                OnSelectCompleted?.Invoke(SelectedCards.Select(x => x.Unwrap()).ToList());
            }
        }

        public void Clear()
        {
            for (int i = 0; i < SelectedCards.Length; i++)
            {
                SelectedCards[i] = Option<PlayerCard>.None();
            }
        }

        public Option<PlayerCard>[] SelectedCards { get; }
        public Action<List<PlayerCard>> OnSelectCompleted { get; set; }
    }
}