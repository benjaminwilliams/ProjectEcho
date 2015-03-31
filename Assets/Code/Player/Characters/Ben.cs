using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Ben : PlayerCharacter {
    public Ben()
    {
        possibleAbilities = new List<Ability> { new BeAwesome().SetCharacter(this) };
    }

    public void Start()
    {
        health = 600000000;
        speed = .2F;
    }
}
