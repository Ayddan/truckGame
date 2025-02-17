using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    public List<AudioClip> clickSounds = new List<AudioClip>();
    public InputActionReference leftClick;
    public AudioSource clickSource;

    public AudioClip keyboardSound;
    public InputActionReference keyboardTap;
    public AudioSource keyboardSource;

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

    private void OnEnable()
    {
        if (leftClick != null)
        {
            leftClick.action.performed += OnLeftClick;
            leftClick.action.Enable();
        }
        //if (keyboardTap != null)
        //{
        //    keyboardTap.action.performed += OnKeyboardTap;
        //    keyboardTap.action.Enable();
        //}
        
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

    private void OnLeftClick(InputAction.CallbackContext context)
    {
        AudioSource audioSource = GetComponent<AudioSource>();

        clickSource.clip = clickSounds[Random.Range(0,2)];
        clickSource.Play();
    }


    // Maybe later
    //private void OnKeyboardTap(InputAction.CallbackContext context)
    //{
    //    keyboardSource.clip = keyboardSound;
    //    keyboardSource.Play();
    //}
}