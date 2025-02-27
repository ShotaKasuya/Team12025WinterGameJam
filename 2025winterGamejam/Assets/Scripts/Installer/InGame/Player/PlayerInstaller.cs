using Domain.IModel.InGame;
using Domain.IModel.InGame.Player;
using Domain.IView.InGame;
using Domain.Presenter.InGame.Player;
using Domain.UseCase.InGame.Player;
using Model.InGame.Player;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using View.InGame.Player;

namespace Installer.InGame.Player
{
    public class PlayerInstaller : LifetimeScope
    {
        [SerializeField] private ProductCardView productCardView;

        private IPlayerIdModel _playerIdModel;

        protected override void Configure(IContainerBuilder builder)
        {
            // View
            builder.RegisterComponent(productCardView);

            // Model
            builder.RegisterInstance(_playerIdModel.PlayerId);

            // Factory
            builder.Register<CardFactory>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.UseEntryPoints(pointsBuilder =>
            {
                // Presenter
                pointsBuilder.Add<NewCardPresenter>();
                pointsBuilder.Add<SelectedCardPresenter>();

                // UseCase
                pointsBuilder.Add<DrawCardCase>();
                pointsBuilder.Add<AddPointCase>();
            });
        }

        [Inject]
        public void Inject(IIdProvideModel playerIdModel)
        {
            _playerIdModel = new PlayerIdModel(playerIdModel.GetId());
        }
    }
}