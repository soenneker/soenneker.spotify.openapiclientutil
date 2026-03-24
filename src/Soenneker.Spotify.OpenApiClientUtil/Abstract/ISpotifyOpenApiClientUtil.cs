using Soenneker.Spotify.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Spotify.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface ISpotifyOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<SpotifyOpenApiClient> Get(CancellationToken cancellationToken = default);
}
