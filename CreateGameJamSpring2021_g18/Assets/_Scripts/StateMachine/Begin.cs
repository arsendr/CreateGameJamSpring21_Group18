using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Begin : State
{
    public Begin(BattleSystem battleSystem) : base(battleSystem)
    {
    }

    public override IEnumerator Start()
    {
        Debug.Log("Strat Begin State!");

        if (GameManager.instance.boss)
        {
            //summon boss
        }
        else
        {
            int minions = Random.Range(3, 5);
            for (int i=0; i<minions; i++)
            {
                Debug.Log("Spawning a minion!");
            }
        }

        yield return new WaitForSeconds(0f);

        BattleSystem.SetState(new PlayerTurn(BattleSystem));
    }
}