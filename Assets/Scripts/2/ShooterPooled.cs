using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterPooled : MonoBehaviour
{
    [SerializeField]
    private BulletPooled bulletPrefab;
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
        var bullet = BulletPool.Instance.Get();
        bullet.transform.rotation = transform.rotation;
        bullet.transform.position = transform.position;
        bullet.gameObject.SetActive(true);
    }
}
