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
            return Id == other.Id;
        }
    }
}