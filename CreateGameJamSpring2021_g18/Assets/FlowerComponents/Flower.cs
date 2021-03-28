using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Flower : PlantComponent
{
    private Element element;
    public override List<SnapPoint> GetSnapPoints()
    {
        Debug.Log("Getting snappoints on flower");
        return new List<SnapPoint>();
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
