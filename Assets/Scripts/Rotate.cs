using UnityEngine;

public class Rotate : MonoBehaviour
{
    private int X;
    private int Y; 
    private int Z;

    private void Start()
    {
        X = Random.Range(1, 15);
        Y = Random.Range(1, 30);
        Z = Random.Range(1, 45);

        transform.localScale = new Vector3(Random.Range(0.5f, 1.5f), Random.Range(0.5f, 1.5f), Random.Range(0.5f, 1.5f));
    }

    void Update()
    {
        transform.Rotate(new Vector3(X, Y, Z) * Time.deltaTime);
    }
}