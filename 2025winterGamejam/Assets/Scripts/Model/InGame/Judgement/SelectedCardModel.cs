using System;
using System.Collections.Generic;
using System.Linq;
using Domain.IModel.Global;
using Domain.IModel.InGame.Judgement;
using Utility.Module.Option;
using Utility.Structure.InGame;

namespace Model.InGame.Judgement
{
    public class SelectedCardModel : IMutSelectedCardModel, ISelectedCardModel
    {
        public SelectedCardModel(IPlayerCountModel playerCountModel)
        {
            SelectedCards = new Option<Card>[playerCountModel.PlayerCount];
        }

        public void StorePlayerSelection(int playerId, Option<Card> selection)
        {
            SelectedCards[playerId] = selection;
            if (SelectedCards.All(x => x.IsSome))
            {
                OnSelectCompleted?.Invoke(SelectedCards.Select(x => x.Unwrap()).ToList());
            }
        }

        public Option<Card>[] SelectedCards { get; }
        public Action<List<Card>> OnSelectCompleted { get; set; }
    }
}