using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private BulletNoPool bulletPrefab;
    [SerializeField]
    private float fireRate = 0.2f;
    private float fireTimer = 0;
    private void Update()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer > fireRate)
        {
            fireTimer = 0;
            Fire();
        }
    }

    private void Fire()
    {
        var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
