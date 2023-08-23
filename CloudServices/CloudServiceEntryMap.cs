using CsvHelper.Configuration;

public class CloudServiceEntryMap : ClassMap<CloudServiceEntry>
{
    public CloudServiceEntryMap()
    {
        Map(m => m.ServiceDomain).Name("Service domain");
        Map(m => m.ServiceName).Name("Service name");
        // Map(m => m.GDPRCompliant).Name("GDPR Compliant").TypeConverterOption.BooleanValues(true, false, "Yes", "No");
        // Map(m => m.CountryOfOrigin).Name("Country of origin");
        // Map(m => m.Risk).Name("Risk");
    }
}