using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public InputActionReference quitAction;

    public float timerDuration = 180f;
    public float bonusTime = 5f;

    public GameObject gameOverScreen;
    public GameObject startScreen;

    public List<AudioClip> clickSounds = new List<AudioClip>();
    public InputActionReference leftClick;
    public AudioSource clickSource;

    public AudioClip keyboardSound;
    public InputActionReference keyboardTap;
    public AudioSource keyboardSource;

    public PlayerController playerController;
    public List<LoadingSpotController> loadingSpotsController;
    public List<TruckController> trucksControllers;
    public StopLineController stopLineController;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
        Time.timeScale = 0f;
    }

    private void Start()
    {
        Debug.Log("Instantiate GameManager...");

        // Player instantiation
        PlayerData playerData = new PlayerData(timerDuration);
        PlayerView playerView = FindFirstObjectByType<PlayerView>();

        playerController = new PlayerController(playerData, playerView, GameOver);

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
        if (quitAction != null)
        {
            quitAction.action.performed += OnQuitAction;
            quitAction.action.Enable();
        }
        
        //if (keyboardTap != null)
        //{
        //    keyboardTap.action.performed += OnKeyboardTap;
        //    keyboardTap.action.Enable();
        //}

    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        startScreen.SetActive(false);
    }
    
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        playerController.AddTime(timerDuration);
        playerController.ResetPlayerScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverScreen.SetActive(false);
        startScreen.SetActive(true);
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
        clickSource.volume = Random.Range(0.5f,1);
        clickSource.Play();
    }

    private void OnQuitAction(InputAction.CallbackContext context)
    {
        Debug.Log("Quit application !");
        Application.Quit();
    }

    // Maybe later
    //private void OnKeyboardTap(InputAction.CallbackContext context)
    //{
    //    keyboardSource.clip = keyboardSound;
    //    keyboardSource.Play();
    //}
}