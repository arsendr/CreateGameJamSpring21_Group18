using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class PlayerTurn : State
{
    public PlayerTurn(BattleSystem battleSystem) : base(battleSystem)
    {
    }

    public override IEnumerator Start()
    {
        Debug.Log("Strat PlayerTurn State!");

        yield return new WaitForSeconds(0f);     
    }

    public override IEnumerator PlayCard()
    {
        Debug.Log("I Played a Card!");

        yield return new WaitForSeconds(2f);

        BattleSystem.SetState(new EnemyTurn(BattleSystem));
    }

    public override IEnumerator SetTarget()
    {
        Debug.Log("You Are a Target!");

        yield return new WaitForSeconds(0f);
    }
}