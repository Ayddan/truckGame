public class LoadingSpotController
{
    LoadingSpotData loadingSpotData;
    LoadingSpotView loadingSpotView;

    public LoadingSpotController(LoadingSpotView loadingSpotView)
    {
        this.loadingSpotData = new LoadingSpotData();
        this.loadingSpotView = loadingSpotView;
    }

    public bool IsLoading()
    {
        return loadingSpotData.isLoading;
    }

    public string GetType()
    {
        return loadingSpotData.type;
    }

    public void ToggleIsLoading()
    {
        loadingSpotData.isLoading = !loadingSpotData.isLoading;
    }

}
