using UnityEngine;
using System.Collections;
using System;

public class DrainEnergy : Ability {
    private bool isFiring = false;
    private Vector3 firingPosition;
    
    public override string GetName()
    {
        return "Drain Energy";
    }

    // Pogi shoots out a beam, the first enemy hit has a minor amount of damage done to them and Pogi gains life force. Channelled
    public override void AbilityTrigger(Vector3 position)
    {
        character.DisallowMovement(1000);
        isFiring = true;
        firingPosition = position;
        firingPosition.z = 0;
    }

    public override void AbilityUpdate()
    {
        if (isFiring)
        {
            if (character.isMovementAllowed && Array.Exists(character.moveDirections, delegate(bool x) { return x; }))
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

                Vector3 newPosition = character.gameObject.transform.position;
                newPosition.x = firingPosition.x - character.gameObject.transform.position.x;
                newPosition.y = firingPosition.y - character.gameObject.transform.position.y;
                float rotation = Mathf.Atan2(newPosition.x, newPosition.y) * 180 / Mathf.PI * -1;
                rotation = rotation * Mathf.Deg2Rad + Mathf.PI / 2;

                newPosition.x = character.gameObject.transform.position.x + Mathf.Cos(rotation) * 6;
                newPosition.y = character.gameObject.transform.position.y + Mathf.Sin(rotation) * 6;

                Debug.DrawLine(character.gameObject.transform.position, newPosition, Color.green);
                RaycastHit hitObject;
                if (Physics.Raycast(character.gameObject.transform.position, newPosition, out hitObject))
                {
                    if (hitObject.transform.gameObject != null)
                    {
                        character.resource += 1;
                        Character boss = hitObject.transform.gameObject.GetComponent<Character>();
                        boss.TakeDamage(1);
                        Debug.Log(character.resource);
                    }
                }
            }
        }
    }
}
