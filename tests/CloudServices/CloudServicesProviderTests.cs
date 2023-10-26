using FluentAssertions;

namespace tests;

public class CloudservicesProviderTests
{
    private readonly CloudServicesProvider _cloudServicesProvider;

    public CloudservicesProviderTests()
    {
        _cloudServicesProvider = new CloudServicesProvider();
    }

    [Fact]
    public void ValidateParsingOfCsv()
    {
        _cloudServicesProvider.LoadCloudServicesFromFile(@"C:\Personal\Git\Cloud-services-used-according-to-firewall-logs\tests\CloudServices\TestsInput\ServiceDBInput_standard.csv");

        _cloudServicesProvider.CloudServiceEntries.Should().HaveCount(6);
        _cloudServicesProvider.CloudServiceEntries[2].Risk.Should().Be(Risk.Low);
        _cloudServicesProvider.CloudServiceEntries[2].CountryOfOrigin.Should().Be("US");
        _cloudServicesProvider.CloudServiceEntries[2].ServiceName.Should().Be("Azure");
        _cloudServicesProvider.CloudServiceEntries[2].GDPRCompliant.Should().Be(true);

    }
}