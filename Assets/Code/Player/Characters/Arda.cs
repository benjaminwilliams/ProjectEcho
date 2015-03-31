using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Arda : PlayerCharacter {
    public void Start()
    {
        health = 1000;
        maxHealth = 1000;
        speed = .08F;
        resource = 200;
        resourceMax = 400;
    }

    public Arda()
    {
        possibleAbilities = new List<Ability> { new Meditation().SetCharacter(this) };
    }

    public override void Update()
    {
        base.Update();
    }
}
