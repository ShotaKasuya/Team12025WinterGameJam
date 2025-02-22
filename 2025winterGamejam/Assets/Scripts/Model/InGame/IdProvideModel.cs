using Domain.IModel.InGame;
using Utility.Structure.InGame;

namespace Model.InGame
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