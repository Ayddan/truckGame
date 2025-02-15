using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public PlayerController playerController;
    public List<LoadingSpotController> loadingSpotsController;
    public List<TruckController> trucksControllers;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Start()
    {
        Debug.Log("Instantiate GameManager...");

        // Player instantiation
        PlayerData playerData = new PlayerData();
        PlayerView playerView = FindFirstObjectByType<PlayerView>();

        playerController = new PlayerController(playerData, playerView);

        // Loading spots inst
        loadingSpotsController = new List<LoadingSpotController>();

        // Trucks list inst
        trucksControllers = new List<TruckController>();

        Debug.Log("GameManager instantiated !");
    }

    public void NewTruck(TruckController controller)
    {
        trucksControllers.Add(controller);
    }

    public void NewLoadingSpot(LoadingSpotController loadingSpotController)
    {
        loadingSpotsController.Add(loadingSpotController);
    }

    public void DeselectActiveTruck()
    {
        TruckController truckController = trucksControllers.Find(controller =>  controller.IsTruckSelected());
        if (truckController != null)
        {
            truckController.ToggleSelectTruck();
        }
    }


}