using Soenneker.Spotify.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Spotify.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class SpotifyOpenApiClientUtilTests : HostedUnitTest
{
    private readonly ISpotifyOpenApiClientUtil _openapiclientutil;

    public SpotifyOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<ISpotifyOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
