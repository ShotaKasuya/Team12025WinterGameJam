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
        public class MockPlayerCountModel : IMutPlayerCountModel
    {
        public int PlayerCount{get;private set;}
        public void SetPlayerCount(int count)
        {
            PlayerCount = count;
        }
    }
}