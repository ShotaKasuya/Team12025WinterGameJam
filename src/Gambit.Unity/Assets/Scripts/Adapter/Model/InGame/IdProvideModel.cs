using Gambit.Unity.Adapter.IModel.InGame;
using Gambit.Unity.Structure.Utility.InGame;

namespace Gambit.Unity.Adapter.Model.InGame
{
    public class IdProvideModel: IIdProvideModel
    {
        private int _count;
        
        public PlayerId GetId()
        {
            return new PlayerId(_count++);
        }
    }
}