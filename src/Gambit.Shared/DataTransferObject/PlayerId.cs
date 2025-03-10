namespace Gambit.Shared.DataTransferObject
{
    public struct PlayerId
    {
        public PlayerId(int id)
        {
            this.id = id;
        }

        private int id;
        public int Id => id;
    }
}