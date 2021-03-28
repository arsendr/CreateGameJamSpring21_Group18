using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class EnemyTurn : State
{
    public EnemyTurn(BattleSystem battleSystem) : base(battleSystem)
    {
        
    }

    public override IEnumerator Start()
    {
        Debug.Log("Strat EnemyTurn State!");
        yield return new WaitForSeconds(2f);
        
        Debug.Log("Enemy is Not Smart Enough to Play!");
        BattleSystem.SetState(new Attack(BattleSystem));
    }
}