using UnityEngine;
using System.Collections;
using System.Timers;

public abstract class PlayerCharacter : Character {
    public abstract void AbilityOne(Vector3 position);
    public abstract void AbilityTwo(Vector3 position);
    //public abstract void AbilityThree(Vector3 position);
    protected bool[] moveDirections = new bool[4];
    private Timer movementTimer;
    protected static bool isMovementAllowed = true;
    
    public override void update()
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
}
