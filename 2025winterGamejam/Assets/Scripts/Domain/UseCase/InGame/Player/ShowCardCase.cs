using System;
using System.Collections.Specialized;
using Domain.IModel.InGame.Player;
using Domain.IPresenter.InGame.Player;
using ObservableCollections;
using Utility.Structure.InGame;

namespace Domain.UseCase.InGame.Player
{
    /// <summary>
    /// カードをドローしたとき等に新しいカードを作成する
    /// </summary>
    public class ShowCardCase : IDisposable
    {
        public ShowCardCase
        (
            IHandCardPresenter handCardPresenter,
            IHandCardModel handCardModel
        )
        {
            HandCardPresenter = handCardPresenter;
            HandCardModel = handCardModel;

            handCardModel.HandCards
                .CollectionChanged += OnCollectionChanged;
        }

        private void OnCollectionChanged(in NotifyCollectionChangedEventArgs<Card> args)
        {
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                {
                    HandCardPresenter.ShowNewCard(args.NewItem);
                    break;
                }
                case NotifyCollectionChangedAction.Remove:
                {
                    HandCardPresenter.DeleteCard(args.NewItem);
                    break;
                }
            }
        }

        private IHandCardPresenter HandCardPresenter { get; }
        private IHandCardModel HandCardModel { get; }

        public void Dispose()
        {
            HandCardModel.HandCards
                .CollectionChanged += OnCollectionChanged;
        }
    }
}