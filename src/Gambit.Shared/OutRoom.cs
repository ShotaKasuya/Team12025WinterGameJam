using System.Threading.Tasks;
using MagicOnion;

namespace Gambit.Shared
{
    /// <summary>
    /// 入室処理
    /// マッチの結果
    /// </summary>
    public interface ISearchRoom : IStreamingHub<ISearchRoom, ISearchRoomReceiver>
    {
        ValueTask JoinAsync(string userName);
        
        ValueTask MatchResultAsync(string result);
    }
    public interface ISearchRoomReceiver 
    {
        
        void Join(string userName);
        void MatchResult(string machResult);

    }
}