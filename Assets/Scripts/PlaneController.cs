using UnityEngine;
using UnityEngine.InputSystem;

public class PlaneController : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    public float offset;
    public bool moveEnabled;

    private Rigidbody rb;
    private Vector2 moveInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        HandlePlayerMovement();
    }

    private void Update()
    {
        Camera.main.transform.position = new Vector3(0, offset, Camera.main.transform.position.z);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void HandlePlayerMovement()
    {
        if(!moveEnabled) return;

        Vector3 move = new Vector3(moveInput.x * turnSpeed, moveInput.y * turnSpeed, moveSpeed) * Time.deltaTime;

        rb.MovePosition(transform.position + move);
    }
}