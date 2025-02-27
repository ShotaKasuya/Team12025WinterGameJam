using System.Collections.Generic;
using Domain.IView.InGame;
using Utility.Structure.InGame;
namespace Domain.IView.InGame
{
    public interface IGetPrefab
    {
        public ProductCardView GetProductCardView(Card card);
    }
}