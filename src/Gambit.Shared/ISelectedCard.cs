using System.Threading.Tasks;
using Gambit.Shared.DataTransferObject;
using MagicOnion;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;

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