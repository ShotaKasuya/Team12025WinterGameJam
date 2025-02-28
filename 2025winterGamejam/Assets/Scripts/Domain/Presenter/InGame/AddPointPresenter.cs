using Cysharp.Threading.Tasks;
using Domain.IPresenter.InGame;
using Adapter.IView.InGame.Ui;
using DG.Tweening;
using System.Linq;

// <summary>
// 加点時演出
// </summary>
namespace Domain.Presenter.InGame
{
    public class AddPointPresenter: IAddPointPresenter
    {
        public AddPointPresenter
        (
            IAddPointTextView addPointTextView
        )
        {
            AddPointTextView = addPointTextView;
        }
        public async UniTask PresentAddPoint(int[] points)
        {
            var fadeInDuration = AddPointTextView.FadeInDuration;
            var fadeOutDuration = AddPointTextView.FadeOutDuration;
            var PointText = AddPointTextView.Text;

            for(int i=0;i<points.Length;i++)
            {
                if(i!=0)
                {
                    PointText.text += " vs ";
                }
                PointText.text += points[i];
            }

            await PointText.DOFade(100,fadeInDuration).AsyncWaitForCompletion();

            await PointText.DOFade(0,fadeOutDuration).AsyncWaitForCompletion();
        }
        private IAddPointTextView AddPointTextView {get;}
    }
}