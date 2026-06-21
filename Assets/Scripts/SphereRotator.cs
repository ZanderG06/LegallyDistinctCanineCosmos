using UnityEngine;

public class SphereRotator : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 30) * Time.deltaTime);
    }
}
