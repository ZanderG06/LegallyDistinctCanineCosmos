using UnityEngine;
using UnityEngine.InputSystem;

public class PlaneController : MonoBehaviour
{
    public float currentSpeed;
    public float moveSpeed;
    public float brakeSpeed;
    public float boostSpeed;

    public float turnSpeed;
    public float offset;
    public float energyChangeRate;

    private ServiceHub serviceHub;
    private bool moveEnabled = true;
    private bool isBraking = false;
    private bool isBoosting = false;
    public float energy = 100;
    private Rigidbody rb;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        serviceHub = ServiceHub.Instance;
    }

    private void FixedUpdate()
    {
        HandlePlayerMovement();
    }

    private void Update()
    {
        Camera.main.transform.position = new Vector3(0, offset, Camera.main.transform.position.z);

        if(isBoosting)
        {
            energy -= energyChangeRate * Time.deltaTime;

            if (energy <= 0)
            {
                energy = 0;
                currentSpeed = moveSpeed;
            }
        }
        else if (isBraking)
        {
            energy -= energyChangeRate * Time.deltaTime;

            if (energy <= 0)
            {
                energy = 0;
                currentSpeed = moveSpeed;
            }
        }
        else
        {
            if (energy >= 100)
            {
                energy = 100;
                return;
            }

            energy += energyChangeRate * Time.deltaTime;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnShoot()
    {
        serviceHub.BulletManager.Shoot();
    }

    public void OnBoost(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            currentSpeed = boostSpeed;
            isBoosting = true;
        }
        else if (context.canceled)
        {
            currentSpeed = moveSpeed;
            isBoosting = false;
        }
    }

    public void OnBrake(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            currentSpeed = brakeSpeed;
            isBraking = true;
        }
        else if (context.canceled)
        {
            currentSpeed = moveSpeed;
            isBraking = false;
        }
    }

    private void HandlePlayerMovement()
    {
        if(!moveEnabled) return;

        Vector3 move = new Vector3(moveInput.x * turnSpeed, moveInput.y * turnSpeed, currentSpeed) * Time.deltaTime;

        rb.MovePosition(transform.position + move);
    }
}