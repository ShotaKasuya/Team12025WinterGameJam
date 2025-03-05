using Gambit.Unity.Adapter.IModel.InGame.Judgement;
using Gambit.Unity.Domain.IUseCase.InGame;
using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Domain.UseCase.InGame
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