using UnityEngine;
using System.Collections;
using System;

public class Pogi : PlayerCharacter {
    private int lifeForce;
    private bool isFiring;
    private Vector3 firingPosition;

    public GameObject bulletPrefab;
    public GameObject targetedEnemy;
	
	// Update is called once per frame
	public void Update() {
        base.update();
        if (isFiring)
        {
            FireLifeForceBeam();
        }
	}

    public void Start()
    {
        health = 600;
        speed = .1F;
    }

    // Pogi shoots out a beam, the first enemy hit has a minor amount of damage done to them and Pogi gains life force. Channelled
    public override void AbilityOne(Vector3 position)
    {
        DisallowMovement(1000);
        isFiring = true;
        firingPosition = position;
        firingPosition.z = 0;
    }

    public override void AbilityTwo(Vector3 position)
    {
        /*GameObject bullet = (GameObject)Network.Instantiate(bulletPrefab, gameObject.transform.position, gameObject.transform.rotation, 0);
        bullet.SendMessage("ShootAt", targetedEnemy);
        shootTimer = Time.time;*/
    }

    private void FireLifeForceBeam()
    {
        if (isMovementAllowed && Array.Exists(moveDirections, delegate (bool x) { return x; }))
        {
            isFiring = false;
        }
        else 
        {
            RaycastHit hit;
            Ray ray;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                firingPosition = Vector3.MoveTowards(firingPosition, hit.point, .1F);
                firingPosition.z = -1;
            }
            
            Vector3 newPosition = gameObject.transform.position;
            newPosition.x = firingPosition.x - gameObject.transform.position.x;
            newPosition.y = firingPosition.y - gameObject.transform.position.y;
            float rotation = Mathf.Atan2(newPosition.x, newPosition.y) * 180 / Mathf.PI * -1;
            rotation = rotation * Mathf.Deg2Rad + Mathf.PI / 2;

            newPosition.x = gameObject.transform.position.x + Mathf.Cos(rotation) * 6;
            newPosition.y = gameObject.transform.position.y + Mathf.Sin(rotation) * 6;

            Debug.DrawLine(gameObject.transform.position, newPosition, Color.green);
            RaycastHit hitObject;
            if (Physics.Raycast(gameObject.transform.position, newPosition, out hitObject))
            {
                if (hitObject.transform.gameObject != null)
                {
                    lifeForce += 1;
                    Character boss = hitObject.transform.gameObject.GetComponent<Character>();
                    boss.TakeDamage(1);
                    Debug.Log(lifeForce);
                }
            }
        }
    }
}
