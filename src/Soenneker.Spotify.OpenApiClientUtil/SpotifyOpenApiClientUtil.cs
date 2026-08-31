using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Spotify.HttpClients.Abstract;
using Soenneker.Spotify.OpenApiClientUtil.Abstract;
using Soenneker.Spotify.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Spotify.OpenApiClientUtil;

public sealed class SpotifyOpenApiClientUtil : ISpotifyOpenApiClientUtil
{
    private readonly AsyncSingleton<SpotifyOpenApiClient> _client;

    public SpotifyOpenApiClientUtil(ISpotifyOpenApiHttpClient httpClientUtil, IConfiguration _)
    {
        _client = new AsyncSingleton<SpotifyOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient)
            {
                BaseUrl = httpClient.BaseAddress!.ToString().TrimEnd('/')
            };

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
