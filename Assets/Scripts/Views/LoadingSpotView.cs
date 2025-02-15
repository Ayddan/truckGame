using System;
using UnityEngine;

public class LoadingSpotView : MonoBehaviour
{
    public GameObject loadingLight;
    public LoadingSpotController loadingSpotsController;

    private void Start()
    {
        loadingSpotsController = new LoadingSpotController(this);
        GameManager.Instance.NewLoadingSpot(loadingSpotsController);
    }

    // Update is called once per frame
    void Update()
    {
        if (loadingSpotsController.IsLoading()) { 
            loadingLight.SetActive(true);
        } else
        {
            loadingLight.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("truck") && !loadingSpotsController.IsLoading())
        {
            loadingSpotsController.ToggleIsLoading();
            collision.gameObject.GetComponent<TruckView>().StartLoading();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("truck"))
        {
            loadingSpotsController.ToggleIsLoading();
        }
    }

}
