using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour {
    public enum Direction { Up, Down, Left, Right };
    protected int health;
    public float speed;

    virtual public void update()
    {
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
}
