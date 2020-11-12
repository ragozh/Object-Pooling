using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed = 10f;
    private float lifeTime;
    private float maxlifeTime = 5f;
    private void OnEnable()
    {
        lifeTime = 0;
    }
    private void Update()
    {
        transform.Translate(-transform.right * moveSpeed * Time.deltaTime);
        lifeTime += Time.deltaTime;
        if (lifeTime > maxlifeTime)
        {
            ShootPool.Instance.ReturnToPool(this);
        }
    }
}
