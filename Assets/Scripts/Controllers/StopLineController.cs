public class StopLineController
{
    private StopLineData data;
    private StopLineView view;

    public StopLineController(StopLineView view)
    {
        this.view = view;
        this.data = new StopLineData();
    }

    public void SetIsOccupied(bool isOccupied)
    {
        this.data.isOccupied = isOccupied;
    }

    public bool IsOccupied()
    {
        return this.data.isOccupied;
    }
}