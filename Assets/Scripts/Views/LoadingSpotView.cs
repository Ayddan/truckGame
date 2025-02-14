using System;
using UnityEngine;

public class LoadingSpotView : MonoBehaviour
{
    public int id = 0;
    public GameObject loadingLight;

    public LoadingSpotData spotData;

    private void Start()
    {
        spotData = new LoadingSpotData();
    }

    // Update is called once per frame
    void Update()
    {
        spotData = GameManager.Instance.loadingSpotsController.GetLoadingSpotData(id);
        if (spotData.isLoading) { 
            loadingLight.SetActive(true);
        } else
        {
            loadingLight.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("truck") && !spotData.isLoading)
        {
            spotData.isLoading = true;
            GameManager.Instance.loadingSpotsController.UpdateLoadingSpot(spotData);
            //TODO : Créer un mvc pour le truck et l'utiliser ici
            collision.gameObject.GetComponent<truckControl>().StartLoading();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("truck"))
        {
            spotData.isLoading = false;
            //TODO : Créer un mvc pour le truck et l'utiliser ici
            GameManager.Instance.loadingSpotsController.UpdateLoadingSpot(spotData);
        }
    }

}
