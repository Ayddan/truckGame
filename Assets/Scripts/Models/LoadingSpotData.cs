
[System.Serializable]
public class LoadingSpotData
{
    public string id;
    public LoadSpotType type;
    public bool isLoading;

    public LoadingSpotData(LoadSpotType cargoType, LoadSpotType loadSpotType)
    {
        id = System.Guid.NewGuid().ToString(); // Generates a unique identifier
        type = loadSpotType;
    }
}
