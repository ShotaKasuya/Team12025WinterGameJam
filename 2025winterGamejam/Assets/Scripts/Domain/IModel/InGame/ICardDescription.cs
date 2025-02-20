using Utility.Structure.InGame;

namespace Domain.IModel.InGame
{
    public interface ICardDescription
    {
        public string EffectName { get; }
        public string Description { get; }
    }
}