using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleStemTargetSelf : Stem
{
    private List<Fighter> tempfighty; //replace withg player

    public override void Activate(List<Fighter> target, int intensity)
    {
        if (this.GetChildPlantComponents() != null)
        {
        this.GetChildPlantComponents()[0].Activate( tempfighty ,intensity);
        Debug.Log("Activaty "+intensity.ToString());
        }
    }

    public override string CardText(int intensity)
    {
        return ""+this.GetChildPlantComponents()[0].CardText(intensity);
    }



    // Start is called before the first frame update
    void Start()
    {
        this.Initialize();

    }

    // Update is called once per frame


    //testy is for testing, balete!!!
    void Update()
    {
        this.DoSomeDebuggingNonsense();
    }
}
