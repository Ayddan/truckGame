public class TruckController
{
    private TruckData truckData;
    private TruckView truckView;
    
    public TruckController(TruckView truckView)
    {
        this.truckView = truckView;
        this.truckData = new TruckData();
    }

    public bool IsTruckSelected()
    {
        return this.truckData.isSelected;
    }

    public bool IsLoading()
    {
        return this.truckData.isLoading;
    }

    public bool IsTruckLoaded()
    {
        return this.truckData.loaded;
    }

    public bool IsReady()
    {
        return this.truckData.isReady;
    }

    public void SetIsReady(bool value)
    {
        this.truckData.isReady = value;
    }

    public LoadSpotType GetLoadType()
    {
        return truckData.type;
    }

    public void ToggleSelectTruck()
    {
        this.truckData.isSelected = !this.truckData.isSelected;
    }

    public void SetTruckLoaded()
    {
        this.truckData.loaded = true;
    }

    public void ToggleLoadedTruck()
    {
        this.truckData.loaded = !this.truckData.loaded;
    }

    public void ToggleTruckLoading()
    {
        this.truckData.isLoading = !this.truckData.isLoading;
    }

    public bool IsJobDone()
    {
        return this.truckData.jobDone;
    }

    public void SetJobDone(bool value)
    {
        this.truckData.jobDone = value;
    }
}