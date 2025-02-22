using Domain.IModel.InGame;
using Domain.IModel.InGame.Player;
using Utility.Structure.InGame;

namespace Model.InGame.Player
{
    public class PlayerDeckModel : IPlayerDeckModel, IDeckInitializable
    {
        public PlayerDeckModel
        (
            IPlayerIdModel playerIdModel,
            IDeckModel deckModel
        )
        {
            PlayerIdModel = playerIdModel;
            DeckModel = deckModel;
        }

        public Deck Deck => DeckModel.Decks[PlayerIdModel.PlayerId.Id];

        public void InitDeck(Deck deck)
        {
            throw new System.NotImplementedException();
        }
        
        private IPlayerIdModel PlayerIdModel { get; }
        private IDeckModel DeckModel { get; }
    }
}