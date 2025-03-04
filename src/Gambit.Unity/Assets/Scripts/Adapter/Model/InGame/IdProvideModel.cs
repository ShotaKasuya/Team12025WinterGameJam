using Adapter.IModel.InGame;
using Utility.Structure.InGame;

namespace Adapter.Model.InGame
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