using UnityEngine;

public class TruckView: MonoBehaviour
{
    [Header("Car Settings")]
    public CargoType cargoType;
    public float acceleration = 5f;      // Acceleration force
    public float maxSpeed = 10f;         // Maximum speed
    public float steering = 2f;          // Steering intensity
    public float loadingSpeed = .2f;
    public GameObject greenLight;

    public Rigidbody2D rb;
    public Animator animator;
    private float moveInput;
    private float steerInput;

    public TruckController truckController;

    void Start()
    {
        truckController = new TruckController(this, cargoType);
        GameManager.Instance.NewTruck(truckController);
    }

    void Update()
    {
        // Get player input
        moveInput = Input.GetAxis("Vertical");    // W/S or Up/Down for throttle
        steerInput = Input.GetAxis("Horizontal"); // A/D or Left/Right for turning
    }

    void FixedUpdate()
    {
        if (truckController.IsTruckSelected())
        {
            greenLight.SetActive(true);
        }
        else
        {
            greenLight.SetActive(false);
            return;
        }
        if (truckController.IsLoading()) return;
        MoveCar();
        SteerCar();
    }

    private void OnMouseDown()
    {
        GameManager.Instance.DeselectActiveTruck();
        truckController.ToggleSelectTruck();
    }

    void MoveCar()
    {
        if (moveInput != 0)
        {
            // Apply force in the forward direction
            rb.AddForce(transform.up * moveInput * acceleration, ForceMode2D.Force);

            // Limit speed
            if (rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
        }
    }

    void SteerCar()
    {
        if (rb.linearVelocity.magnitude > 0.1f) // Only steer when moving
        {
            // Check if moving forward or backward in local space
            float localVelocityY = transform.InverseTransformDirection(rb.linearVelocity).y;
            float directionMultiplier = localVelocityY < 0 ? -1 : 1; // Invert steering if moving backward

            float turn = -steerInput * steering * rb.linearVelocity.magnitude * 0.1f * directionMultiplier;
            rb.rotation += turn;
        }
    }

    public void EndLoading()
    {
        truckController.ToggleTruckLoading();
        truckController.ToggleLoadedTruck();
        animator.SetBool("Loaded", truckController.IsTruckLoaded());
    }
    public void StartLoading()
    {
        truckController.ToggleTruckLoading();
        animator.SetTrigger("Load");
    }
}