using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int health;
    [SerializeField] private int[] elementalResistance = {0,0,0,0,0,0};
    public void ApplyDamage(Element elementalType, int amount)
    {
        health -= (int)(amount * 1-(elementalResistance[(int)elementalType] / 100));
        Debug.Log("ouch!"+(int)health+(int)amount);
        if (health <= 0)
        {
            Destroy(this.gameObject);
            
        }
    }

    

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
