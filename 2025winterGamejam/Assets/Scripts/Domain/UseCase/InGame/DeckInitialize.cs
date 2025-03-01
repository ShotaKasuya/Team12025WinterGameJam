using Adapter.IModel.InGame.Judgement;
using Domain.IUseCase.InGame;
using Utility.Structure.InGame;

namespace Domain.UseCase.InGame
{
    public class DeckHandCardInitialize : IDeckInitCase
    {
        public DeckHandCardInitialize
        (
            IMutDeckModel deckModel
        )
        {
            DeckModel = deckModel;
        }

        public void DeckInitialize()
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