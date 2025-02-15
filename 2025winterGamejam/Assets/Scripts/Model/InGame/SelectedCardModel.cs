using System;
using System.Collections.Generic;
using System.Linq;
using Domain.IModel.InGame;
using Module.Option;
using Structure.InGame;

namespace Model.InGame
{
    public class SelectedCardModel: ISelectedCardModel, ISelectionEventModel
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