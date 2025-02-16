public class TruckController
{
    private TruckData truckData;
    private TruckView truckView;
    
    public TruckController(TruckView truckView, CargoType cargoType)
    {
        this.truckView = truckView;
        this.truckData = new TruckData(cargoType);
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

    public CargoType GetType()
    {
        return truckData.type;
    }

    public void ToggleSelectTruck()
    {
        this.truckData.isSelected = !this.truckData.isSelected;
    }

    public void ToggleLoadedTruck()
    {
        this.truckData.loaded = !this.truckData.loaded;
    }

    public void ToggleTruckLoading()
    {
        this.truckData.isLoading = !this.truckData.isLoading;
    }
}