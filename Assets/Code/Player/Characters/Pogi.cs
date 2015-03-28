using UnityEngine;
using System.Collections;
using System;

public class Pogi : PlayerCharacter {
    private int lifeForce;
    private bool isFiring;
    private Vector3 firingPosition;
	
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
        Debug.Log("Ab 1");
        DisallowMovement(1000);
        isFiring = true;
        firingPosition = position;
        firingPosition.z = 0;
    }

    public override void AbilityTwo(Vector3 position)
    {
        
    }

    private void FireLifeForceBeam()
    {
        if (isMovementAllowed && Array.Exists(moveDirections, delegate (bool x) { return x; }))
        {
            Debug.Log("In here?");
            isFiring = false;
        }
        else 
        {
            Vector3 newPosition = gameObject.transform.position;
            float distance = Vector3.Distance(gameObject.transform.position, firingPosition);
            newPosition.x = firingPosition.x + (firingPosition.x - gameObject.transform.position.x) / distance * 3;
            newPosition.y = firingPosition.y + (firingPosition.y - gameObject.transform.position.y) / distance * 3;

            Debug.DrawLine(gameObject.transform.position, newPosition, Color.green);
        }
    }
}
