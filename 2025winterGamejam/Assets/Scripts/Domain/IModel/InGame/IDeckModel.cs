using System.Collections.Generic;
using Structure.InGame;

namespace Domain.IModel.InGame
{
    public interface IDeckModel
    {
        public List<Deck> Decks{get;}
    }

    public interface IHandCard
    {
        public List<HandCard> HandCards{get;}
    }
}