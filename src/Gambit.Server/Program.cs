using System.Net;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace Gambit.Server
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.WebHost.UseKestrel(options =>
            {
                options.ConfigureEndpointDefaults(endpointOptions =>
                {
                    endpointOptions.Protocols = HttpProtocols.Http2;
                });

                // HTTP/1.1エンドポイントの設定
                options.Listen(IPAddress.Parse("0.0.0.0"), 5000,
                    listenOptions => { listenOptions.Protocols = HttpProtocols.Http1; });

                // HTTP/2, HTTPSエンドポイントの設定
                options.Listen(IPAddress.Parse("0.0.0.0"), 5001, listenOptions =>
                {
                    // --load-cert=true が指定されていたら証明書を読み込む
                    if (args.Any(arg => arg == "--load-cert=true"))
                    {
                        Console.WriteLine("load certificate");
                        listenOptions.UseHttps(new X509Certificate2("certificate/certificate.pfx", "test"));
                    }
                });
            });

            builder.Services.AddGrpc();
            builder.Services.AddMagicOnion();
            var app = builder.Build();

            // テスト用エンドポイント
            app.MapGet("/", () => "Hello World!");
            
            // MagicOnionのエンドポイント
            app.MapMagicOnionService();

            app.Run();
        }
    }
}