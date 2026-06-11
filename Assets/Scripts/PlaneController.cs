using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float moveSpeed;

    private void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
