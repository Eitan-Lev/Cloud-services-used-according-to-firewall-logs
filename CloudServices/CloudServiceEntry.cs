using CsvHelper.Configuration.Attributes;

public class CloudServiceEntry
{
    [Name("Service name")]
    public string ServiceName { get; set; }

    [Name("Service domain")]
    public string ServiceDomain { get; set; }

    [Name("Risk")]
    public Risk Risk { get; set; }

    [Name("Country of origin")]
    public string CountryOfOrigin { get; set; }

    [Name("GDPR Compliant")]
    public bool GDPRCompliant { get; set; }
}