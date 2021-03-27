using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleContainer : MonoBehaviour
{
    Fighter playerFighter;
    List<Fighter> enemies;

    public List<Fighter> GetEnemies()
    {
        return enemies;
    }
    public Fighter GetPlayer()
    {
        return playerFighter;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
