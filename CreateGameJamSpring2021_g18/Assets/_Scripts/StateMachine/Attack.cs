using System.Collections;
using System.Collections.Generic;
using UnityEngine;


internal class Attack : State
{
    public Attack(BattleSystem battleSystem) : base(battleSystem)
    {

    }
    public override IEnumerator Start()
    {
        foreach (GameObject item in BattleSystem.EnemyPositions)
        {
            foreach (DerpCard attackCard in BattleSystem.enemyAttacks)
            {
                attackCard.Use(BattleSystem.PlayerPosition.GetComponentInChildren<Fighter>());
            }         
        }

        yield return new WaitForSeconds(0f);     
    }
}