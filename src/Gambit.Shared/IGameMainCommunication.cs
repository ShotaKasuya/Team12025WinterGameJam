using System.Threading.Tasks;
using Gambit.Shared.DataTransferObject;
using MagicOnion;

namespace Gambit.Shared
{
    /// <summary>
    /// 入室処理
    /// マッチの結果
    /// 言葉の主体はクライアント
    /// </summary>
    public interface IGameMainCommunication : IStreamingHub<IGameMainCommunication, IGameMainReceiver>
    {
        /// <summary>
        /// 部屋に入室する
        /// </summary>
        ValueTask<PlayerInitInfoTransferObject> JoinAsync();

        /// <summary>
        /// 退室する
        /// </summary>
        ValueTask LeaveAsync(PlayerIdTransferObject playerIdTransferObject);
        
        /// <summary>
        /// カードを選択した際に呼ぶ
        /// </summary>
        /// <param name="playerCardTransferObject">カードの情報</param>
        ValueTask SendSelectedCardAsync(PlayerCardTransferObject playerCardTransferObject);
    }
    public interface IGameMainReceiver 
    {
        /// <summary>
        /// マッチングが完了した際に呼ばれる
        /// </summary>
        void OnMatch(PlayersInfoTransferObject playersInfo);
        
        /// <summary>
        /// 他プレイヤーがカードを選択した際に呼ばれる
        /// </summary>
        /// <param name="playerCardTransferObject"></param>
        void SendSelectedCard(PlayerCardTransferObject playerCardTransferObject);
    }
}