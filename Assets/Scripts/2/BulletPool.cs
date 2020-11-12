using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField]
    private BulletPooled bulletPrefab;
    private Queue<BulletPooled> bullets = new Queue<BulletPooled>();
    public static BulletPool Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    public BulletPooled Get()
    {
        if (bullets.Count == 0)
            AddBullet(1);

        return bullets.Dequeue();
    }

    private void AddBullet(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            BulletPooled bullet = Instantiate(bulletPrefab);
            bullet.gameObject.SetActive(false);
            bullets.Enqueue(bullet);
        }
    }

    public void ReturnToPool(BulletPooled bullet)
    {
        bullet.gameObject.SetActive(false);
        bullets.Enqueue(bullet);
    }
}
