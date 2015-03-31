using UnityEngine;
using System.Collections;
using System;

public class Meditation : Ability {
    private bool isFiring = false;
    private Vector3 firingPosition;
    
    public override string GetName()
    {
        return "Meditation";
    }

    // Pogi shoots out a beam, the first enemy hit has a minor amount of damage done to them and Pogi gains life force. Channelled
    public override void AbilityTrigger(Vector3 position)
    {
        
    }

    public override void AbilityUpdate()
    {
        
    }
}
