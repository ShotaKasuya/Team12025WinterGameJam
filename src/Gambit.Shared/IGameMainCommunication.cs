using System.Threading.Tasks;
using Gambit.Shared.DataTransferObject;
using MagicOnion;

namespace Gambit.Shared
{
    /// <summary>
    /// 入室処理
    /// マッチの結果
    /// </summary>
    public interface IGameMainCommunication : IStreamingHub<IGameMainCommunication, IGameMainReceiver>
    {
        /// <summary>
        /// 部屋に入室した際の処理
        /// </summary>
        /// <param name="userName"></param>
        ValueTask JoinAsync(string userName);
        
        ValueTask MatchResultAsync(string result);
        
        /// <summary>
        /// ゲーム中、カードを選択した際に呼ばれる
        /// </summary>
        /// <param name="playerCardTransferObject">カードの情報</param>
        ValueTask SendSelectedCardAsync(PlayerCardTransferObject playerCardTransferObject);
    }
    public interface IGameMainReceiver 
    {
        /// <summary>
        /// 入室が完了した際に呼ばれる
        /// </summary>
        /// <param name="userName"></param>
        void OnJoin(string userName);
        
        void MatchResult(string machResult);
        
        /// <summary>
        /// 他プレイヤーがカードを選択した際に呼ばれる
        /// </summary>
        /// <param name="playerCardTransferObject"></param>
        void SendSelectedCard(PlayerCardTransferObject playerCardTransferObject);
    }
}