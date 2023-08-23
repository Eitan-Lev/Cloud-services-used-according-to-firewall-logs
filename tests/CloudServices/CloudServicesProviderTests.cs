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
    public void VerifyCorrectCountOfItems()
    {
        _cloudServicesProvider.LoadCloudServicesFromFile(@"c:\GitRepos\WizExcersize\Cloud-services-used-according-to-firewall-logs\tests\CloudServices\TestsInput\ServiceDBInput_basic.csv");

        _cloudServicesProvider.CloudServiceEntries.Should().HaveCount(6);
    }

    [Fact]
    public void ValidateParsingOfCsv()
    {
        _cloudServicesProvider.LoadCloudServicesFromFile(@"c:\GitRepos\WizExcersize\Cloud-services-used-according-to-firewall-logs\tests\CloudServices\TestsInput\ServiceDBInput_standard.csv");

        _cloudServicesProvider.CloudServiceEntries.Should().HaveCount(6);
    }
}