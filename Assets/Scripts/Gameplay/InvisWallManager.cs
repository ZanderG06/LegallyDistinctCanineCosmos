using UnityEngine;

public class InvisWallManager : MonoBehaviour
{
    private float startingX;
    private float startingY;
    private ServiceHub serviceHub;

    private void Start()
    {
        startingX = transform.position.x;
        startingY = transform.position.y;

        serviceHub = ServiceHub.Instance;
    }

    private void Update()
    {
        transform.position = new Vector3(startingX, startingY, serviceHub.PlaneController.currentZ);
    }
}