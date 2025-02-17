using UnityEngine;

public class LoadingSpotView : MonoBehaviour
{
    public LoadSpotType spotType;
    public GameObject loadingLight;
    public GameObject greenLight;
    public GameObject redLight;
    public bool haveError = false; 
    public LoadingSpotController loadingSpotsController;

    private void Start()
    {
        loadingSpotsController = new LoadingSpotController(this, spotType);
        GameManager.Instance.NewLoadingSpot(loadingSpotsController);
    }

    // Update is called once per frame
    void Update()
    {
        if (loadingSpotsController.IsLoading())
        {
            loadingLight.SetActive(true);
            greenLight.SetActive(false);
            redLight.SetActive(false);
        }
        else if (haveError)
        {
            greenLight.SetActive(false);
            redLight.SetActive(true);
        }
        else
        {
            greenLight.SetActive(true);
            loadingLight.SetActive(false);
            redLight.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("truck") && !loadingSpotsController.IsLoading())
        {
            TruckView truckView = collision.gameObject.GetComponent<TruckView>();
            if (truckView.truckController.GetLoadType() == loadingSpotsController.GetType() && !truckView.truckController.IsJobDone())
            {
                loadingSpotsController.ToggleIsLoading();
                truckView.StartLoading();
                haveError = false;
            }
            else
            {
                haveError = true;
            }
        }else
        {
            haveError = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("truck") && loadingSpotsController.IsLoading())
        {
            loadingSpotsController.ToggleIsLoading();
        } else
        {
            haveError = false;
        }
    }

}
