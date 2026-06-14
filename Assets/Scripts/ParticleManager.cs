using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    private float startingX;
    private float startingY;

    private void Start()
    {
        startingX = transform.position.x;
        startingY = transform.position.y;
    }

    private void Update()
    {
        transform.position = new Vector3(startingX, startingY, transform.position.z);
    }
}