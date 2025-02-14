using System.Collections.Generic;
using Domain.IModel.InGame;
using Structure.InGame;
namespace Domain.UseCase.InGame
{
    public class DrawCardCase
    {
        
        public DrawCardCase
        (
            IDeckModel deckModel,
            IHandCard handCard,
            IGameStartEventModel gameStartEventModel,
            IDrawCardEventModel drawCardEventModel
        )//=public DrawCardCase(IDeckModel DeckModel,IHandCard HandCard, IGameStartEventModel GameStartEventModel, IDrawCardEventModel DrawCardEventModel)
        {


            DeckModel = deckModel;
            HandCard = handCard;
            GameStartEventModel = gameStartEventModel;
            DrawCardEventModel = drawCardEventModel; 
        }
        private void DrawCrad(List<Deck> deck,List<HandCard> handCard)
        {
            //handCard.Cards
        }

        private IDeckModel DeckModel{get;}
        private IHandCard HandCard{get;}
        private IGameStartEventModel GameStartEventModel{get;}
        private IDrawCardEventModel DrawCardEventModel{get;}
    }
}