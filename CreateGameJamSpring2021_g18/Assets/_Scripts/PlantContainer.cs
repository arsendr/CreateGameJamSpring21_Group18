using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantContainer : MonoBehaviour
{
    [SerializeField] private SnapPoint containerPlantSnapper;
    // Start is called before the first frame update
    public PlantComponent GetPlantComponent()
    {
        return containerPlantSnapper.getConnectedPlantComponent();
    }
    public void SetPlantComponent()
    {
        
        containerPlantSnapper.Attach(GetComponent<Pot>().PotList[0].GetComponent<PlantContainer>().GetPlantComponent());
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
