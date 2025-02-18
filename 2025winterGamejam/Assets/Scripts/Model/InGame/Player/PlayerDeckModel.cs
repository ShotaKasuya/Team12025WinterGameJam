using Domain.IModel.InGame.Player;
using Utility.Structure.InGame;

namespace Model.InGame.Player
{
    public class PlayerDeckModel: IDeckModelPlayer, IDeckInitializable
    {
        public Deck Deck { get; private set; }
        public void InitDeck(Deck deck)
        {
            Deck = deck;
        }
    }
}