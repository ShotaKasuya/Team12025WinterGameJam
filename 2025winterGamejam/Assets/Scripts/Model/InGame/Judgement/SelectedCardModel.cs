using System;
using System.Collections.Generic;
using System.Linq;
using Domain.IModel.InGame.Judgement;
using Utility.Module.Option;
using Utility.Structure.InGame;

namespace Model.InGame.Judgement
{
    public class SelectedCardModel: IMutSelectedCardModel, ISelectedCardModel
    {
        public void StorePlayerSelection(int playerId, Option<Card> selection)
        {
            SelectedCards[playerId] = selection;

            if (!SelectedCards.Any(x => x.IsNone))
            {
                OnAllPlayerSelectedCard?.Invoke(SelectedCards.Select(x => x.Unwrap()).ToList());
            }
        }

        public Action<List<Card>> OnAllPlayerSelectedCard { get; set; }

        private List<Option<Card>> SelectedCards { get; } = new List<Option<Card>>();
    }
}