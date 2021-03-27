using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract  class Stem : PlantComponent
{
    [SerializeField] private List<SnapPoint> SnapPoints = new List<SnapPoint>();
    public override List<SnapPoint> GetSnapPoints()
    {
        return SnapPoints;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
