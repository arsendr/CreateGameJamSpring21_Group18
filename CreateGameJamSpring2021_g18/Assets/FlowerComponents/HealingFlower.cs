using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingFlower : Flower
{
    [SerializeField] private Element _element;

    public override void Activate(List<Fighter> target, int intensity)
    {
        foreach (Fighter currentTarget in target)
        {
            //currentTarget.ApplyDamage(_element,intensity);
        }
    }

    public override string CardText(int intensity)
    {
        return "Heal "+intensity.ToString();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DoSomeDebuggingNonsense();
    }
}
