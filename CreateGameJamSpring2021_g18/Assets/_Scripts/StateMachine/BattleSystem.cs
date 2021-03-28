using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : StateMachine
{
/*
    [SerializeField] private ArenaUI ui;
    [SerializeField] private Fighter player;
    [SerializeField] private List<Fighter> enemies;

    public ArenaUI UI => ui;
    public Fighter Player => player;
    public List<Fighter> Enemies =>enemies
*/
    public List<GameObject> EnemyPositions;
    public GameObject PlayerPosition;
    public List<GameObject> BossEnemies;
    public GameObject fighterPrefab;
    public List<Card> enemyAttacks;

    private void Start()
    {

        // Initialize UI and deck

        SetState(new Begin(this));
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(State.PlayCard());
        }
    }
    public void SpawnFighter(int i)
    {
        Instantiate(this.fighterPrefab,this.EnemyPositions[i].transform);
    }
    public void SpawnPlayer()
    {
        Instantiate(this.fighterPrefab,this.PlayerPosition.transform);
        PlayerPosition.GetComponentInChildren<Fighter>().SetHealth(100);
    }
}
