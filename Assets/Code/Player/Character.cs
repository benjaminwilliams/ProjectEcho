using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour {
    public enum Direction { Up, Down, Left, Right };
    protected int health;
    public float speed;
    protected int maxHealth;

    virtual public void Update()
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

    public void HealDamage(int healAmount)
    {
        health += healAmount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        Debug.Log(health);
    }
}
