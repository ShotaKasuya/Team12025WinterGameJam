using System.Threading.Tasks;
using Gambit.Shared.DataTransferObject;
using MagicOnion;

namespace Gambit.Shared
{
    public interface ISelectedCardSender : IStreamingHub<ISelectedCardSender, ISelectedCardReceiver>
    {
        ValueTask SendSelectedCardAsync(SentPlayerCard sentPlayerCard);
    }

    public interface ISelectedCardReceiver
    {
        void SendSelectedCard(SentPlayerCard sentPlayerCard);
    }
}