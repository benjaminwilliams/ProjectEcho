using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Pogi : PlayerCharacter {
    public Pogi()
    {
        possibleAbilities = new List<Ability> { new DrainEnergy().SetCharacter(this) };
    }

    public void Start()
    {
        health = 600;
        speed = .1F;
    }
}
