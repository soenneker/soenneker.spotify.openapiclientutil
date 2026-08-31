using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Spotify.HttpClients.Registrars;
using Soenneker.Spotify.OpenApiClientUtil.Abstract;

namespace Soenneker.Spotify.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the lazily initialized Spotify Web API client.
/// </summary>
public static class SpotifyOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds the Spotify API client utility as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddSpotifyOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddSpotifyOpenApiHttpClientAsSingleton()
                .TryAddSingleton<ISpotifyOpenApiClientUtil, SpotifyOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds the Spotify API client utility as a scoped service backed by the singleton HTTP client provider. <para/>
    /// </summary>
    public static IServiceCollection AddSpotifyOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddSpotifyOpenApiHttpClientAsSingleton()
                .TryAddScoped<ISpotifyOpenApiClientUtil, SpotifyOpenApiClientUtil>();

        return services;
    }
}
