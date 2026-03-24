using Soenneker.Spotify.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Spotify.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class SpotifyOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly ISpotifyOpenApiClientUtil _openapiclientutil;

    public SpotifyOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<ISpotifyOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
