using UnityEngine;

public class Menu_Planets : MonoBehaviour
{
    private float rotationSpeed = 30f;

    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
