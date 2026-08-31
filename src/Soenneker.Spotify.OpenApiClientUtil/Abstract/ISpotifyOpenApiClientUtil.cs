using Soenneker.Spotify.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Spotify.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a lazily initialized Spotify Web API client.
/// </summary>
public interface ISpotifyOpenApiClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the shared client for this utility instance.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<SpotifyOpenApiClient> Get(CancellationToken cancellationToken = default);

    /// <summary>Releases resources used by this utility.</summary>
    new void Dispose();

    /// <summary>Asynchronously releases resources used by this utility.</summary>
    new ValueTask DisposeAsync();
}
