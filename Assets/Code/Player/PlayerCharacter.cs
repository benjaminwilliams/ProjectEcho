using UnityEngine;
using System.Collections;
using System.Timers;
using System.Collections.Generic;

public abstract class PlayerCharacter : Character {
    //public abstract void AbilityThree(Vector3 position);
    public bool[] moveDirections = new bool[4];
    private Timer movementTimer;
    public bool isMovementAllowed = true;
    public delegate void UseAbility(Vector3 position);
    protected UseAbility abilityOne;
    public int resource;
    protected List<Ability> possibleAbilities;
    protected List<Ability> abilities = new List<Ability>();
    
    public override void Update()
    {
        if (GetComponent<NetworkView>().isMine)
        {
            if (isMovementAllowed)
            {
                if (moveDirections[(int)Direction.Up])
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + speed, gameObject.transform.position.z);
                }
                if (moveDirections[(int)Direction.Down])
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - speed, gameObject.transform.position.z);
                }
                if (moveDirections[(int)Direction.Left])
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x - speed, gameObject.transform.position.y, gameObject.transform.position.z);
                }
                if (moveDirections[(int)Direction.Right])
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x + speed, gameObject.transform.position.y, gameObject.transform.position.z);
                }
            }
        }
        foreach (Ability ability in abilities)
        {
            ability.AbilityUpdate();
        }
    }

    public void StartMove(Direction direction)
    {
        moveDirections[(int)direction] = true;
    }

    public void StopMove(Direction direction)
    {
        moveDirections[(int)direction] = false;
    }

    public void DisallowMovement(double timeToStop)
    {
        if (movementTimer == null)
        {
            isMovementAllowed = false;
            movementTimer = new Timer(timeToStop);
            movementTimer.Elapsed += AllowMovement;
            movementTimer.Enabled = true;
        }
    }

    private void AllowMovement(object sender, ElapsedEventArgs e)
    {
        isMovementAllowed = true;
        movementTimer.Dispose();
        movementTimer = null;
    }

    public void AbilityOne(Vector3 position)
    {
        abilities[0].AbilityTrigger(position);
    }

    public void AbilityTwo(Vector3 position)
    {
        abilities[1].AbilityTrigger(position);
    }

    public List<Ability> GetAbilities()
    {
        return possibleAbilities;
    }

    public void SetAbility(int abilityIndex)
    {
        abilities.Add(possibleAbilities[abilityIndex]);
    }
}
