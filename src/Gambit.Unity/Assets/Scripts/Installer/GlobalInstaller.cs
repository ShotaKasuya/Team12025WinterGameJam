using Cysharp.Net.Http;
using Gambit.Unity.Adapter.IView.UseCommunication;
using Gambit.Unity.Adapter.Model.Global;
using Gambit.Unity.Adapter.Model.InGame;
using Gambit.Unity.Adapter.View.Communication;
using Grpc.Net.Client;
using MagicOnion;
using MagicOnion.Unity;
using VContainer;
using VContainer.Unity;

namespace Gambit.Unity.Installer
{
    public class GlobalInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // Initialize gRPC channel provider when the application is loaded.
            GrpcChannelProviderHost.Initialize(new DefaultGrpcChannelProvider(() => new GrpcChannelOptions()
            {
                HttpHandler = new YetAnotherHttpHandler()
                {
                    Http2Only = true,
                },
                DisposeHttpClient = true,
            }));
            
            var channel = GrpcChannelx.ForAddress("http://localhost:5001");
            // var channel = GrpcChannelx.ForAddress("http://game.gambit-server.com:5001");

            builder.RegisterInstance(channel);
            builder.Register<GameMainReceiverView>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<GameMainSenderView>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<PlayerIdModel>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<RoomInfoModel>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void Start()
        {
            var sender = Container.Resolve<IConnectView>();
            sender.Connect();
        }
    }
}