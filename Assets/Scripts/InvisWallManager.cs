using UnityEngine;

public class InvisWallManager : MonoBehaviour
{
    private float startingX;
    private float startingY;
    private float moveSpeed = 5f;

    private void Start()
    {
        startingX = transform.position.x;
        startingY = transform.position.y;
    }

    private void Update()
    {
        transform.position = new Vector3(startingX, startingY, transform.position.z);
        transform.Translate(moveSpeed * Time.deltaTime * transform.forward);
    }
}