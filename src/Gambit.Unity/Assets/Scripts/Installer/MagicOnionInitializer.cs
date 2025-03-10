using System;
using Cysharp.Net.Http;
using Gambit.Shared;
using Grpc.Net.Client;
using MagicOnion;
using MagicOnion.Client;
using MagicOnion.Unity;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Gambit.Unity.Installer
{
    public class MagicOnionInitializer : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void OnRuntimeInitialize()
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
        }

        async void Start()
        {
            try
            {
                var channel = GrpcChannelx.ForAddress("http://game.gambit-server.com:5001");
                var client = MagicOnionClient.Create<IMyFirstService>(channel);

                Debug.Log("send 100 + 200");
                var result = await client.SumAsync(100, 200);
                Debug.Log($"100 + 200 = {result}");
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}