using Gambit.Shared.DataTransferObject;
using MagicOnion;

namespace Gambit.Shared
{
    public interface ISelectedCard : IStreamingHub<ISelectedCard, ISelectedCardReceiver>
    {
        
    }

    public interface ISelectedCardReceiver
    {
        void SendSelectedCard(Card card);
    }
}