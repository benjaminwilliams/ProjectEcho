using UnityEngine;
using System.Collections;

public class BossOneBullet : AICharacter {
    public void Update()
    {
        base.update();
        if(!isMoving)
        {
            Network.Destroy(gameObject);
        }
    }

    public void Start()
    {
        speed = 30F;
        isMoving = true;
    }

    public void ShootAt(GameObject target)
    {
        MoveTo(target.transform.position);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) { 
            collision.gameObject.SendMessage("TakeDamage", 50);
            Network.Destroy(gameObject);
        }
    }
}
