using System.Collections;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletLifeTime;

    private bool canShoot = true;
    private float startingZ;
    private MeshRenderer meshRenderer;
    private Vector3 position;

    private void Start()
    {
        startingZ = transform.localPosition.z;
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }

    public void Shoot()
    {
        if (!canShoot) return;

        canShoot = false;
        meshRenderer.enabled = true;
        StartCoroutine(MoveBullets());
    }

    IEnumerator MoveBullets()
    {
        float timer = 0f;

        while (timer < bulletLifeTime)
        {
            transform.Translate(bulletSpeed * Time.deltaTime * transform.forward);
            timer += Time.deltaTime;

            yield return null;
        }

        meshRenderer.enabled = false;
        canShoot = true;
        
        transform.localPosition = new Vector3(position.x, position.y, startingZ);
    }
}