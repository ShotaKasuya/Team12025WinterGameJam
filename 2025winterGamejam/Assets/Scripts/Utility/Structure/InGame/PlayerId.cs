
namespace Utility.Structure.InGame
{
    public struct PlayerId
    {
        public PlayerId(int id)
        {
            Id = id;
        }
        public int Id { get; }

        public bool Equals(PlayerId other)
        {
            return Id==other.Id;
        }
        public static PlayerId StorePlayerId(int id)
        {
            var Id = new PlayerId(id);
            return Id;
        }
    }
}