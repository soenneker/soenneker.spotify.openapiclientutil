using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Spotify.HttpClients.Registrars;
using Soenneker.Spotify.OpenApiClientUtil.Abstract;

namespace Soenneker.Spotify.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class SpotifyOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="SpotifyOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddSpotifyOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddSpotifyOpenApiHttpClientAsSingleton()
                .TryAddSingleton<ISpotifyOpenApiClientUtil, SpotifyOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="SpotifyOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddSpotifyOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddSpotifyOpenApiHttpClientAsSingleton()
                .TryAddScoped<ISpotifyOpenApiClientUtil, SpotifyOpenApiClientUtil>();

        return services;
    }
}
