using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour {
    public enum Direction { Up, Down, Left, Right };
    
    private bool[] moveDirections = new bool[4];
    protected bool isMoving = false;
    protected int health;

    public float speed;

    virtual public void update()
    {
        if (GetComponent<NetworkView>().isMine)
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

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log(health);
    }

    public void StartMove(Direction direction)
    {
        moveDirections[(int)direction] = true;
    }

    public void StopMove(Direction direction)
    {
        moveDirections[(int)direction] = false;
    }
}
