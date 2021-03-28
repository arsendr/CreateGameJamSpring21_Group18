using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    [SerializeField] private int effect;
    // Start is called before the first frame update
    
    public void Use(GameObject target)
    {
        target.GetComponent<Fighter>().ApplyDamage(effect);
    }

    public string GetEffect()
    {
        return "effect";
    }
}
