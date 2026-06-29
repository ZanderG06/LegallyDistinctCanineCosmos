using UnityEngine;
using UnityEngine.InputSystem;

public class PlaneController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float currentSpeed;
    public float moveSpeed;
    public float brakeSpeed;
    public float boostSpeed;
    public float turnSpeed;
    public bool invertY;

    [Header("Thrust Settings")]
    public GameObject thrust;
    public float normalThrust;
    public float brakeThrust;
    public float boostThrust;

    [Header("Max Plane Position")]
    public float maxX;
    public float maxTop;
    public float maxBottom;

    [Header("Rotation Settings")]
    public GameObject planeBody;
    public float maxUpDownRotation;
    public float maxLeftRightRotation;

    [Header("Other")]
    public float offset;
    public float energyChangeRate;

    private ServiceHub serviceHub;
    private bool moveEnabled = true;
    private bool isBraking = false;
    private bool isBoosting = false;
    public float energy = 100;
    private Rigidbody rb;
    private Vector2 moveInput;

    public float currentZ;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        serviceHub = ServiceHub.Instance;

        ChangeThrustBrightness(normalThrust);
    }

    private void FixedUpdate()
    {
        HandlePlayerMovement();
        HandlePlanePosition();
        HandlePlaneRotation();
    }

    private void Update()
    {
        Camera.main.transform.position = new Vector3(0, offset, Camera.main.transform.position.z);

        HandleEnergy();
    }

    private void HandleEnergy()
    {
        if (isBoosting)
        {
            energy -= energyChangeRate * Time.deltaTime;
            ChangeThrustBrightness(boostThrust);

            if (energy <= 0)
            {
                energy = 0;
                currentSpeed = moveSpeed;
                ChangeThrustBrightness(normalThrust);
            }
        }
        else if (isBraking)
        {
            energy -= energyChangeRate * Time.deltaTime;
            ChangeThrustBrightness(brakeThrust);

            if (energy <= 0)
            {
                energy = 0;
                currentSpeed = moveSpeed;
                ChangeThrustBrightness(normalThrust);
            }
        }
        else
        {
            ChangeThrustBrightness(normalThrust);

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

    public void OnPause()
    {
        ServiceHub.Instance.UIManager.TogglePauseUI();
    }

    private void HandlePlayerMovement()
    {
        if(!moveEnabled) return;
        Vector3 move;

        if(invertY) move = new Vector3(moveInput.x * turnSpeed, moveInput.y * turnSpeed, currentSpeed) * Time.deltaTime;
        else move = new Vector3(moveInput.x * turnSpeed, -moveInput.y * turnSpeed, currentSpeed) * Time.deltaTime;

        rb.MovePosition(transform.position + move);
        currentZ = transform.position.z;
    }

    private void HandlePlanePosition()
    {
        if(transform.position.x > maxX)
        {
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        }
        else if(transform.position.x < -maxX)
        {
            transform.position = new Vector3(-maxX, transform.position.y, transform.position.z);
        }

        if(transform.position.y > maxTop)
        {
            transform.position = new Vector3(transform.position.x, maxTop, transform.position.z);
        }
        else if(transform.position.y < maxBottom)
        {
            transform.position = new Vector3(transform.position.x, maxBottom, transform.position.z);
        }
    }

    private void HandlePlaneRotation()
    {
        float pitch;

        if(invertY) pitch = -moveInput.y * maxUpDownRotation;
        else pitch = moveInput.y * maxUpDownRotation;

        float roll = -moveInput.x * maxLeftRightRotation;

        planeBody.transform.rotation = Quaternion.Euler(pitch, 0f, roll);
    }

    private void ChangeThrustBrightness(float brightness)
    {
        thrust.GetComponent<Renderer>().material.color = new Color(brightness, brightness, brightness);
    }
}