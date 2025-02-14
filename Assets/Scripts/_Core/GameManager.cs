using System.Collections;
using Assets.Scripts.Views;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public PlayerController playerController;
    public LoadingSpotsController loadingSpotsController;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
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
        LoadingSpotsData loadingSpotsData = new LoadingSpotsData();
        LoadingSpotsView loadingSpotsView = FindFirstObjectByType<LoadingSpotsView>();

        loadingSpotsController = new LoadingSpotsController(loadingSpotsData, loadingSpotsView);

        Debug.Log("GameManager instantiated !");
    }
}