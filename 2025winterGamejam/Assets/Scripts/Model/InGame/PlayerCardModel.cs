using System.Collections.Generic;
using Domain.IModel.InGame;
using Structure.InGame;

namespace Model.InGame
{
    public class PlayerCardModelModel: IDeckModel, IHandCardModel
    {
        public List<Deck> Decks { get; } = new List<Deck>();
        public List<HandCard> HandCards { get; } = new List<HandCard>();
    }
}