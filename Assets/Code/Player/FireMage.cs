using UnityEngine;
using System.Collections;

public class FireMage : PlayerCharacter {
    private bool shieldMode = false;
	
	// Update is called once per frame
	public void Update() {
        base.update();
	}

    public void Start()
    {
        health = 600;
        speed = .1F;
    }

    public override void AbilityOne(Vector3 position)
    {
        shieldMode = !shieldMode;
    }

    public override void AbilityTwo(Vector3 position)
    {
        if (shieldMode)
        {
            Collider[] inRangeObjects = Physics.OverlapSphere(gameObject.transform.position, 7);
            foreach(Collider hitObject in inRangeObjects) {
                if (hitObject.gameObject.CompareTag("Enemy"))
                {
                    hitObject.gameObject.SendMessage("TakeDamage", 100);
                }
            }
        }
        else
        {
            if (health < 500)
            {
                health += 100;
            }
            else
            {
                health = 600;
            }
        }
    }
}
