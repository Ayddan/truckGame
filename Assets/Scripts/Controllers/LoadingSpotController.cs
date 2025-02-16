public class LoadingSpotController
{
    LoadingSpotData loadingSpotData;
    LoadingSpotView loadingSpotView;

    public LoadingSpotController(LoadingSpotView loadingSpotView, CargoType type)
    {
        this.loadingSpotData = new LoadingSpotData(type);
        this.loadingSpotView = loadingSpotView;
    }

    public bool IsLoading()
    {
        return loadingSpotData.isLoading;
    }

    public CargoType GetType()
    {
        return loadingSpotData.type;
    }

    public void ToggleIsLoading()
    {
        loadingSpotData.isLoading = !loadingSpotData.isLoading;
    }

}
