namespace Gambit.Unity.Structure.Utility.InGame.Command
{
    public interface IExecutableCommand
    {
        public Class Class { get; } 
        public void Execute();
    }

    /// <summary>
    /// 優先度クラス
    /// </summary>
    public enum Class
    {
        
    }
}