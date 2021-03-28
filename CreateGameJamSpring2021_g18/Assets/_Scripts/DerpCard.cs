using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DerpCard : Card
{
    [SerializeField] private PlantComponent myplant;
    // Start is called before the first frame update
    
    public void Use(Fighter target)
    {
        List<Fighter> mytarget = new List<Fighter>();
        mytarget.Add(target);

        myplant.Activate(mytarget,1);
    }

    public string GetEffect()
    {
        return myplant.CardText(1);
    }
}
