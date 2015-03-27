using UnityEngine;
using System.Collections;

public abstract class PlayerCharacter : Character {
    public abstract void AbilityOne(Vector3 position);
    public abstract void AbilityTwo(Vector3 position);
    //public abstract void AbilityThree(Vector3 position);
}
