using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleStem : Stem
{
    [SerializeField] private List<GameObject> tempyEnemy;

    public override void Activate(List<Fighter> target, int intensity)
    {
        Debug.Log("isfinist");
        if (this.GetChildPlantComponents() != null)
        {
        this.GetChildPlantComponents()[0].Activate(target,intensity++);
        Debug.Log("Activaty "+intensity.ToString());
        }
    }

    public override string CardText(int intensity)
    {
        return ""+this.GetChildPlantComponents()[0].CardText(intensity++);
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
