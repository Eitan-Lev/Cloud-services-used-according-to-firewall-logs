public interface ICloudServicesProvider
{
    List<CloudServiceEntry> CloudServiceEntries { get; set; }

    void LoadCloudServicesFromFile(string pathToFile);
}