using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(1)]
public class BulletPool : MonoBehaviour
{
    GameObject bulletPrefab;
    readonly int poolSize = 15;

    List<GameObject> bulletPool = new();

    void Start()
    {
        bulletPrefab = GameObject.Find("bullet");
        for(int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.tag = "clone";
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    public GameObject GetBullet(int i)
    {
        return bulletPool[i];
    }
}
