using Domain.IModel.InGame.Player;

namespace Presenter.InGame.Player
{
    /// <summary>
    /// 選択されたカードを強調表示する
    /// </summary>
    public class SelectedCardPresenter
    {
        public SelectedCardPresenter
        (
            ISelectedCardModel selectedCardModel
        )
        {
            SelectedCardModel = selectedCardModel;
        }
        
        private ISelectedCardModel SelectedCardModel { get; }
    }
}