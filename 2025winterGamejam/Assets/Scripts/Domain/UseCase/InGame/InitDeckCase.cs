using Domain.IModel.InGame.Judgement;
using Utility.Structure.InGame;
using VContainer.Unity;

namespace Domain.UseCase.InGame
{
    public class InitDeckCase: IInitializable
    {
        public InitDeckCase
            (
                IMutDeckModel deckModel
                )
        {
            DeckModel = deckModel;
        }
        
        public void Initialize()
        {
            var len = DeckModel.Decks.Length;
            var decks = Deck.RandomDecks(len);

            for (int i = 0; i < len; i++)
            {
                DeckModel.Decks[i] = decks[i];
            }
        }
        
        private IMutDeckModel DeckModel { get; }
    }
}