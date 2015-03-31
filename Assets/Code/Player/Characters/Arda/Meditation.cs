using UnityEngine;
using System.Collections;
using System;

public class Meditation : Ability {
    private bool isChanneling = false;
    private float channelCooldownTimer = -1000000;
    private bool isHoTApplied = false;
    private float healTimer;

    public override string GetName()
    {
        return "Meditation";
    }

    
    public override void AbilityTrigger(Vector3 position)
    {
        if (Time.time - channelCooldownTimer > 5)
        {
            character.DisallowMovement(1000);
            isChanneling = true;
            channelCooldownTimer = Time.time;
        }
    }

    public override void AbilityUpdate()
    {
        if (isChanneling && character.isMovementAllowed && Array.Exists(character.moveDirections, delegate(bool x) { return x; }))
        {
            isChanneling = false;
        }
        else if (isChanneling)
        {
            if (character.resource < character.resourceMax)
            {
                character.resource += 1;
                Debug.Log(character.resource);
            }
            else
            {
                // We are at full, so end the channel and give HoT
                isChanneling = false;
                isHoTApplied = true;
                healTimer = Time.time;
            }
        }
        if (isHoTApplied)
        {
            if (Time.time - healTimer > 5)
            {
                isHoTApplied = false;
            }
            character.HealDamage(1);
        }
    }
}
