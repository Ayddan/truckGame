public class LoadingSpotController
{
    LoadingSpotData loadingSpotData;
    LoadingSpotView loadingSpotView;

    public LoadingSpotController(LoadingSpotView loadingSpotView, LoadSpotType type)
    {
        this.loadingSpotData = new LoadingSpotData(type, type);
        this.loadingSpotView = loadingSpotView;
    }

    public bool IsLoading()
    {
        return loadingSpotData.isLoading;
    }

    public LoadSpotType GetType()
    {
        return loadingSpotData.type;
    }

    public void ToggleIsLoading()
    {
        loadingSpotData.isLoading = !loadingSpotData.isLoading;
    }

}
