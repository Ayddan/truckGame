
[System.Serializable]
public class TruckData
{
    public string id;
    public CargoType type;
    public bool isLoading = false;
    public bool loaded = false;
    public bool isSelected = false;
    

    public TruckData(CargoType cargoType)
    {
        id = System.Guid.NewGuid().ToString(); // Generates a unique identifier
        type = cargoType;
    }

}