using UnityEngine;
using System.Collections;

public class BossOne : Character {
    float shootTimer;
    public GameObject bulletPrefab;
    public GameObject targetedEnemy;

    public void Start()
    {
        health = 2000;
        shootTimer = Time.time;
    }

    public void Update()
    {
        if (Time.time - shootTimer > 2)
        {
            if (targetedEnemy != null)
            {
                GameObject bullet = (GameObject)Network.Instantiate(bulletPrefab, gameObject.transform.position, gameObject.transform.rotation, 0);
                bullet.SendMessage("ShootAt", targetedEnemy);
                shootTimer = Time.time;
            }
        }
    }
}
