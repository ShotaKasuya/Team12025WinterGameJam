using System.Threading.Tasks;
using Gambit.Shared;
using Gambit.Shared.DataTransferObject;
using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Adapter.View.Communication
{
    public class SelectedCardReceiver : ISelectedCardReceiver
    {
        PlayerCard PlayerCard;
        public void SendSelectedCard(SentPlayerCard sentPlayerCard)
        {
            PlayerCard.ConversionSentPlayerCard(sentPlayerCard);
        }
        
        private ISelectedCardSender _selectedCardSender;

        public async ValueTask SendCard(SentPlayerCard sentPlayerCard)
        {
            await _selectedCardSender.SendSelectedCardAsync(sentPlayerCard);
        }
    }
}