using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Trigger with Player detected!");
            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Trigger with Bullet detected!");
            Destroy(gameObject);
        }
    }
}
