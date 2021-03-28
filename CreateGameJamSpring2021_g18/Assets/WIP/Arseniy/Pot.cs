using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    [SerializeField] private GameObject card;
    [SerializeField] private float growtime = 10;
    [SerializeField] private bool ready = false;
    
    [SerializeField] private bool testText = false;

    public ParticleSystem PS;
    private void Start()
    {

    }

    private void Update()
    {
        if (testText)
        {
            testText = false;
           GameManager.instance.Deck[0].GetComponent<DerpCard>().GetEffect();
            
        }

        growtime -=Time.deltaTime;
        if (growtime < 0)
        {
            ready = true;
            PS.Play();
        }
    }
    private void OnMouseDown()
    {
        if (ready)
        {
            Debug.Log(card.GetComponent<DerpCard>().GetEffect());
            GameManager.instance.Deck.Add(card);
            PS.Stop();
            ready = false;
            growtime = 10;
        }
    }
}
