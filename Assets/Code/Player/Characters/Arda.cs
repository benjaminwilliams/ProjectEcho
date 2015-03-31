using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Arda : PlayerCharacter {
    public void Start()
    {
        health = 1000;
        speed = .1F;
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
