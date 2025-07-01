using Gambit.Shared.DataTransferObject;
using Gambit.Unity.Utility.Structure.InGame;

namespace Gambit.Unity.Adapter.IView.UseCommunication
{
    /// <summary>
    /// サーバー側のプレイヤーIdとローカルのプレイヤーIdを変換する
    /// </summary>
    public interface IPlayerIdView
    {
        public PlayerId GetPlayerId(PlayerIdTransferObject playerIdTransferObject);
        public PlayerIdTransferObject GetPlayerId(PlayerId playerId);
    }
    
    public interface IPlayerIdInitializeView
    {
        public void Init(PlayerIdTransferObject[] playerIdTransferObjects);
    }
}