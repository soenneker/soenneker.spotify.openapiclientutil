[![](https://img.shields.io/nuget/v/soenneker.spotify.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.spotify.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.spotify.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.spotify.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.spotify.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.spotify.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.spotify.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.spotify.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Spotify.OpenApiClientUtil

Provides a lazily initialized Spotify client for artists, albums, tracks, playlists, shows, episodes, audiobooks, search, recommendations, playback, and the current user's library.

## Installation

```bash
dotnet add package Soenneker.Spotify.OpenApiClientUtil
```

## Configuration

```json
{
  "Spotify": {
    "ApiKey": "your-spotify-access-token"
  }
}
```

## Usage

```csharp
using Soenneker.Spotify.OpenApiClientUtil.Abstract;
using Soenneker.Spotify.OpenApiClientUtil.Registrars;

services.AddSpotifyOpenApiClientUtilAsSingleton();

var client = await spotifyClientUtil.Get(cancellationToken);
var profile = await client.Me.GetAsync(
    cancellationToken: cancellationToken);
```

The access token must include the scopes required by the endpoints you call. Use `AddSpotifyOpenApiClientUtilAsScoped()` for a separate generated wrapper per scope; both registrations retain the singleton authenticated HTTP client provider.
