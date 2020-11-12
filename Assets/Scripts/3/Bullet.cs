using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IGameObjectPooled
{
    public float moveSpeed = 10f;
    private float lifeTime;
    private float maxlifeTime = 5f;
    private GameObjectPool pool;
    public GameObjectPool Pool
    {
        get { return pool; }
        set
        {
            if (pool == null)
                pool = value;
            else
                throw new System.Exception("Error pool");
        }
    }
    private void OnEnable() => lifeTime = 0;
    private void Update()
    {
        transform.Translate(-transform.right * moveSpeed * Time.deltaTime);
        lifeTime += Time.deltaTime;
        if (lifeTime > maxlifeTime)
        {
            pool.ReturnToPool(this.gameObject);
        }
    }
}

internal interface IGameObjectPooled
{
    GameObjectPool Pool { get; set; }
}
