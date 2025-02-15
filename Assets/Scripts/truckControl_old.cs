using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class truckControl_old : MonoBehaviour
{
    //[Header("Car Settings")]
    //public float acceleration = 5f;      // Acceleration force
    //public float maxSpeed = 10f;         // Maximum speed
    //public float steering = 2f;          // Steering intensity
    ////public float drag = 0.99f;           // Simulated friction
    //public float loadingSpeed = .2f;
    //public GameObject greenLight;

    //public Rigidbody2D rb;
    //public Animator animator;
    //private float moveInput;
    //private float steerInput;

    //private TruckData truckData;

    //void Start()
    //{
    //    truckData = new TruckData();
    //}

    //void Update()
    //{
    //    // Get player input
    //    moveInput = Input.GetAxis("Vertical");    // W/S or Up/Down for throttle
    //    steerInput = Input.GetAxis("Horizontal"); // A/D or Left/Right for turning
    //}

    //void FixedUpdate()
    //{
    //    if(isSelected)
    //    {
    //        greenLight.SetActive(true);
    //    } else
    //    {
    //        greenLight.SetActive(false);
    //        return;
    //    }
    //    if(isLoading) return;
    //    MoveCar();
    //    SteerCar();
    //}

    //private void OnMouseDown()
    //{
    //    isSelected = !isSelected;
    //}

    //void MoveCar()
    //{
    //    if (moveInput != 0)
    //    {
    //        // Apply force in the forward direction
    //        rb.AddForce(transform.up * moveInput * acceleration, ForceMode2D.Force);

    //        // Limit speed
    //        if (rb.linearVelocity.magnitude > maxSpeed)
    //        {
    //            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
    //        }
    //    }
    //}

    //void SteerCar()
    //{
    //    if (rb.linearVelocity.magnitude > 0.1f) // Only steer when moving
    //    {
    //        // Check if moving forward or backward in local space
    //        float localVelocityY = transform.InverseTransformDirection(rb.linearVelocity).y;
    //        float directionMultiplier = localVelocityY < 0 ? -1 : 1; // Invert steering if moving backward

    //        float turn = -steerInput * steering * rb.linearVelocity.magnitude * 0.1f * directionMultiplier;
    //        rb.rotation += turn;
    //    }
    //}

    //public void EndLoading()
    //{
    //    isLoading = false;
    //    loaded = !loaded;
    //    animator.SetBool("Loaded", loaded);
    //}
    //public void StartLoading()
    //{
    //    isLoading = true;
    //    animator.SetTrigger("Load");
    //}

}