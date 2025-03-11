using Gambit.Unity.Adapter.IModel.Global;
using Gambit.Unity.Adapter.IModel.InGame.Judgement;
using Gambit.Unity.Domain.IUseCase.InGame;
using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Domain.UseCase.InGame
{
    public class DeckHandCardInitializeCase : IDeckInitCase
    {
        public DeckHandCardInitializeCase
        (
            IRoomInfoModel roomInfoModel,
            IMutDeckModel deckModel
        )
        {
            RoomInfoModel = roomInfoModel;
            DeckModel = deckModel;
        }

        public void DeckInitialize()
        {
            var len = DeckModel.Decks.Length;
            var decks = Deck.RandomDecks(len, RoomInfoModel.RoomSeed);

            for (int i = 0; i < len; i++)
            {
                DeckModel.Decks[i] = decks[i];
            }
        }

        private IRoomInfoModel RoomInfoModel { get; }
        private IMutDeckModel DeckModel { get; }
    }
}