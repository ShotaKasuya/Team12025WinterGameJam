using Adapter.IModel.InGame;
using Adapter.IModel.InGame.Player;
using Adapter.IView.InGame;
using Adapter.Model.InGame.Player;
using Adapter.View.InGame.Player;
using Domain.Presenter.InGame.Player;
using Domain.UseCase.InGame.Player;
using UnityEngine;
using VContainer;
using VContainer.Unity;

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