using Utility.Structure.InGame;

namespace Domain.IModel.InGame
{
    public interface ICardDescription
    {
        public string EffectName(Card card);
        public string Description(Card card);
    }
}