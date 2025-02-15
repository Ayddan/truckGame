
[System.Serializable]
public class TruckData
{
    public string id;
    public bool isLoading = false;
    public bool loaded = false;
    public bool isSelected = false;

    public TruckData()
    {
        id = System.Guid.NewGuid().ToString(); // Generates a unique identifier
    }

}