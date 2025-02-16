using UnityEngine;

public class TruckView: MonoBehaviour
{
    [Header("Car Settings")]
    public CargoType cargoType;
    public float acceleration = 5f;      // Acceleration force
    public float maxSpeed = 10f;
    public float maxBackwardSpeed = 5f;
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
        if(truckController.IsTruckLoaded())
        {
            animator.SetBool("Loaded", truckController.IsTruckLoaded());
        }
        if(!truckController.IsReady())
        {
            GoForward();
        }
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

            // Determine if the object is moving forward or backward
            float dot = Vector2.Dot(rb.linearVelocity, transform.up);

            // Define different speed limits for forward and backward movement
            float forwardMaxSpeed = maxSpeed;       // Max speed when moving forward
            float backwardMaxSpeed = maxSpeed * 0.2f; // Example: 50% speed when moving backward

            // Choose the correct max speed based on movement direction
            float currentMaxSpeed = (dot >= 0) ? forwardMaxSpeed : backwardMaxSpeed;

            // Limit speed if it exceeds the selected max speed
            if (rb.linearVelocity.magnitude > currentMaxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * currentMaxSpeed;
            }
        }
    }

    void GoForward()
    {
        // Apply force in the forward direction
        rb.AddForce(transform.up * 10.0f, ForceMode2D.Force);

        // Limit speed
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
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
        truckController.SetJobDone(true);
    }
    public void StartLoading()
    {
        truckController.ToggleTruckLoading();
        animator.SetTrigger("Load");
    }
}