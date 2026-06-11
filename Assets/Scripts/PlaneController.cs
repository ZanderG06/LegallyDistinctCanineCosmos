using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float moveSpeed;
    public float offset;
    
    private void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.forward);

        Camera.main.transform.position = new Vector3(0, offset, Camera.main.transform.position.z);
    }
}