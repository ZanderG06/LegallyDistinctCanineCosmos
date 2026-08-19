using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public Transform spawnLocation;

    private float startingX;
    private float startingY;

    private void Start()
    {
        startingX = transform.position.x;
        startingY = transform.position.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.SetPositionAndRotation(spawnLocation.position, spawnLocation.rotation);
        transform.position = new Vector3(startingX, startingY, transform.position.z);
        Physics.SyncTransforms();
    }
}