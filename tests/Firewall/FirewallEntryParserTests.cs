using FluentAssertions;

namespace tests;

public class FirewallEntryParserTests
{
    private readonly FirewallEntryParser _firewallEntryParser;

    public FirewallEntryParserTests()
    {
        _firewallEntryParser = new FirewallEntryParser();
    }

    [Fact]
    public void ValidateParsingOfSingleSimpleEntry_WithDomain()
    {
        string[] lines = System.IO.File.ReadAllLines(@"C:\Personal\Git\Cloud-services-used-according-to-firewall-logs\tests\Firewall\TestsInput\FirewallLogInput_singleEntryWithDomain.log");
        lines.Should().HaveCount(1);
        var line = lines.Single();

        var firewallEntry = _firewallEntryParser.Parse(line);
        firewallEntry.SrcIp.Should().Be("11.11.11.71");
        firewallEntry.DstIp.Should().Be("162.125.248.18");
        firewallEntry.Domain.Should().Be("www.dropbox.com");
        firewallEntry.User.Should().BeEmpty();
    }

    [Fact]
    public void ValidateParsingOfSingleSimpleEntry_WithUser()
    {
        string[] lines = System.IO.File.ReadAllLines(@"C:\Personal\Git\Cloud-services-used-according-to-firewall-logs\tests\Firewall\TestsInput\FirewallLogInput_singleEntryWithUser.log");
        lines.Should().HaveCount(1);
        var line = lines.Single();

        var firewallEntry = _firewallEntryParser.Parse(line);
        firewallEntry.SrcIp.Should().Be("192.150.249.87");
        firewallEntry.DstIp.Should().Be("11.11.11.84");
        firewallEntry.Domain.Should().BeEmpty();
        firewallEntry.User.Should().Be("dave@acme.com");
    }

    [Fact]
    public void ValidateParsingOfSingleSimpleEntry_Complex()
    {
        string[] lines = System.IO.File.ReadAllLines(@"C:\Personal\Git\Cloud-services-used-according-to-firewall-logs\tests\Firewall\TestsInput\FirewallLogInput_singleEntryComplex.log");
        lines.Should().HaveCount(1);
        var line = lines.Single();

        var firewallEntry = _firewallEntryParser.Parse(line);
        firewallEntry.SrcIp.Should().Be("11.11.11.71");
        firewallEntry.DstIp.Should().Be("162.125.248.18");
        firewallEntry.Domain.Should().Be("www.dropbox.com");
        firewallEntry.User.Should().Be("dave@acme.com");
    }
}