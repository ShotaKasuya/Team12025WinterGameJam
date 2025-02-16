using IView.InGame;

namespace Domain.IPresenter.InGame
{
    /// <summary>
    /// ファクトリからカードのインスタンスを受取と解放を行うインターフェース
    /// </summary>
    public interface ICardReceivable
    {
        public void ReceiveCard(ICardView cardView);
        public void ReleaseCard(ICardView cardView);
    }
}