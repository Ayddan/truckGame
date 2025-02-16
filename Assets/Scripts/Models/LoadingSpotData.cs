
[System.Serializable]
public class LoadingSpotData
{
    public string id;
    public CargoType type;
    public bool isLoading;

    public LoadingSpotData(CargoType cargoType)
    {
        id = System.Guid.NewGuid().ToString(); // Generates a unique identifier
        type = cargoType;
    }
}
