using System.Reflection.Metadata;

public class FirewallEntryParser
{
    public FirewallEntry Parse(string line)
    {
        var cols = line.Split(new char[] { ' ', '/' }, StringSplitOptions.RemoveEmptyEntries);

        var firewallEntry = new FirewallEntry();
        firewallEntry.SrcIp = cols.Where(value => value.StartsWith("SRC=")).Select(value => value.Substring(4)).Single();
        firewallEntry.DstIp = cols.Where(value => value.StartsWith("DST=")).Select(value => value.Substring(4)).Single();
        
        var domain = cols.Where(value => value.StartsWith("DOMAIN="));
        if (domain.Count() == 0)
        {
            firewallEntry.Domain = string.Empty;
        }
        else 
        {
            firewallEntry.Domain = domain.Single().Substring(7);
        }

        var user = cols.Where(value => value.StartsWith("USER="));
        if (user.Count() == 0)
        {
            firewallEntry.User = string.Empty;
        }
        else 
        {
            firewallEntry.User = user.Single().Substring(5);
        }

        return firewallEntry;
    }
}