using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);


builder.WebHost.ConfigureKestrel((context, serverOptions) =>
{
    serverOptions.ListenAnyIP(8443, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http3;
        // openssl pkcs12 -inkey server.key -in server.crt -export -out cert.pfx
        listenOptions.UseHttps("server.pfx", "password");
    });
});
builder.WebHost.UseUrls("https://localhost.esodemoapp2.com:8443");
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

