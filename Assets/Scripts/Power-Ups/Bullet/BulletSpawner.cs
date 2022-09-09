using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] protected List<GameObject> bullets;
    public GameObject BulletPrefab;
    protected Vector3 initialPush;
    protected BrickBehaviour brickProper;
    protected Bullet bullet;

    void Start()
    {
        SetupMagazineSize();
    }

    void Update()
    {
        SpawnBullet();
    }

    protected void SpawnBullet()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {         
            InstantiateBullet();
            UseBulletPull();
            bullets.Remove(BulletPrefab);
        }
    }

    protected void SetupMagazineSize()
    {

    }

    protected void UseBulletPull()
    {
        bullets.Remove(BulletPrefab);
    }

    protected void InstantiateBullet()
    {
        Instantiate(BulletPrefab);
    }

}
