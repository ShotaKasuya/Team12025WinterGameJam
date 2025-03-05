namespace Gambit.Unity.Adapter.IModel.Global
{
    /// <summary>
    /// プレイヤー人数を持つモデル
    /// </summary>
    public interface IMutPlayerCountModel: IPlayerCountModel
    {
        public void SetPlayerCount(int playerCount);
    }
    public interface IPlayerCountModel
    {
        public int PlayerCount { get; }
    }
}