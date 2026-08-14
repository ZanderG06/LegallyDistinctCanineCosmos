using UnityEngine;
using UnityEngine.UIElements;

public class Explosions : MonoBehaviour
{
    float minX = -2;
    float maxX = 1;
    float minZ = 13f;
    float maxZ = 16f;

    private Animator explosion;

    private void Start()
    {
        explosion = GetComponent<Animator>();
        FirstAnimation();
    }

    private void FirstAnimation()
    {
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        transform.position = new Vector3(randomX, transform.position.y, randomZ);
        explosion.Play("Explosion", 0, Random.value);
    }

    public void StartAnimation()
    {
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        transform.position = new Vector3(randomX, transform.position.y, randomZ);
        explosion.Play("Explosion");
    }
}
