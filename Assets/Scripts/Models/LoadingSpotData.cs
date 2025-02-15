
[System.Serializable]
public class LoadingSpotData
{
    public string id;
    public string type;
    public bool isLoading;

    public LoadingSpotData()
    {
        id = System.Guid.NewGuid().ToString(); // Generates a unique identifier
    }
}
