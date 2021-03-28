using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int health;

    public void ApplyDamage(int amount)
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);           
        }
    }

    public void SetHealth(int value)
    {
        maxHealth = value;
        health = value;
    }

    

    // Start is called before the first frame update
    void Awake()
    {
        health = maxHealth;
    }

}
