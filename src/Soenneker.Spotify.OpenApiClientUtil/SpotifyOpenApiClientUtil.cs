using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Spotify.HttpClients.Abstract;
using Soenneker.Spotify.OpenApiClientUtil.Abstract;
using Soenneker.Spotify.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Spotify.OpenApiClientUtil;

///<inheritdoc cref="ISpotifyOpenApiClientUtil"/>
public sealed class SpotifyOpenApiClientUtil : ISpotifyOpenApiClientUtil
{
    private readonly AsyncSingleton<SpotifyOpenApiClient> _client;

    public SpotifyOpenApiClientUtil(ISpotifyOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<SpotifyOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Spotify:ApiKey");
            string authHeaderValueTemplate = configuration["Spotify:AuthHeaderValueTemplate"] ?? "{token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

            return new SpotifyOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<SpotifyOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
