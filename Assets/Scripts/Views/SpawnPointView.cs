using UnityEngine;

public class SpawnPointView : MonoBehaviour
{
    public GameObject truck; // Assign this in the Unity Inspector
    public float spawnInterval = 1f; // Time in seconds

    void Start()
    {
        // Start spawning the prefab every 10 seconds
        InvokeRepeating(nameof(SpawnPrefab), 0f, spawnInterval);
    }

    void SpawnPrefab()
    {
        if (truck != null && !GameManager.Instance.stopLineController.IsOccupied())
        {
            //CargoType randomCargo = GetRandomCargoType();
            //truck.GetComponent<TruckView>().cargoType = randomCargo
            GameObject truckInstance = Instantiate(truck, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Prefab is not assigned in SpawnPointView!");
        }
    }
}
