using Domain.IModel.InGame.Judgement;
using Domain.IModel.InGame.Player;
using Utility.Structure.InGame;

namespace Model.InGame.Player
{
    public class PlayerDeckModel : IPlayerDeckModel, IDeckInitializable
    {
        public PlayerDeckModel
        (
            PlayerId playerIdModel,
            IMutDeckModel deckModel
        )
        {
            PlayerIdModel = playerIdModel;
            DeckModel = deckModel;
        }

        public Deck Deck => DeckModel.Decks[PlayerIdModel.Id];

        public void InitDeck(Deck deck)
        {
            throw new System.NotImplementedException();
        }
        
        private PlayerId PlayerIdModel { get; }
        private IMutDeckModel DeckModel { get; }
    }
}