using System.Globalization;
using CsvHelper;

public class CloudServicesProvider : ICloudServicesProvider
{
    public List<CloudServiceEntry> CloudServiceEntries { get; set; }

    public CloudServicesProvider()
    {
        CloudServiceEntries = new List<CloudServiceEntry>();
    }

    public void LoadCloudServicesFromFile(string pathToFile)
    {
        using (var reader = new StreamReader(pathToFile))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<CloudServiceEntryMap>();
            CloudServiceEntries = csv.GetRecords<CloudServiceEntry>().ToList();
        }
    }
}