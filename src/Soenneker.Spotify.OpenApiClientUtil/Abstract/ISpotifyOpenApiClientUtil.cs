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
    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<SpotifyOpenApiClient> Get(CancellationToken cancellationToken = default);
}
