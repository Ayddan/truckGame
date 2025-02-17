
using System;

[System.Serializable]
public class TruckData
{
    public string id;
    public LoadSpotType type;
    public bool isLoading = false;
    public bool loaded = false;
    public bool isSelected = false;
    public bool isReady = false;
    public bool jobDone = false;


    public TruckData()
    {
        id = System.Guid.NewGuid().ToString(); // Generates a unique identifier

        Random random = new Random();
        if (random.Next(2) == 1)
        {
            loaded = true;
            type = LoadSpotType.Unloading;
        }else
        {
            type = LoadSpotType.Loading;
        }
    }

}