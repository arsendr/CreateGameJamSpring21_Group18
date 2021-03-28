using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantContainer : MonoBehaviour
{
    public SnapPoint containerPlantSnapper;
    // Start is called before the first frame update
    public PlantComponent GetPlantComponent()
    {
        return containerPlantSnapper.getConnectedPlantComponent();
    }
    public void SetPlantComponent()
    {
        
        containerPlantSnapper.Attach();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
