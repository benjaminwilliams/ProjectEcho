using UnityEngine;
using System.Collections;
using System;

public abstract class Ability {
    public PlayerCharacter character;
    public abstract void AbilityUpdate();
    public abstract void AbilityTrigger(Vector3 position);
    public abstract string GetName();

    public Ability SetCharacter(PlayerCharacter character)
    {
        this.character = character;
        return this;
    }
}
