using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StemDoAll : Stem
{

    public override void Activate(List<Fighter> target, int intensity)
    {
        if (this.GetChildPlantComponents() != null)
        {
            foreach (PlantComponent currentComponent in this.GetChildPlantComponents())
            {
                        currentComponent.Activate(target,intensity);
            }

        Debug.Log("Activaty "+intensity.ToString());
        }
    }

    public override string CardText(int intensity)
    {
        string returnText = "";
           foreach (PlantComponent currentComponent in this.GetChildPlantComponents())
            {
                returnText += currentComponent.CardText(intensity)+"\n";
            }
        return returnText;
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
