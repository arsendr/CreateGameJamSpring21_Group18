using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapPoint : MonoBehaviour
{
    [SerializeField] private PlantComponent connected;
    // Start is called before the first frame update
    public PlantComponent getConnectedPlantComponent()
    {
        return connected;
    }
    void Start()
    {
        if (connected != null)
        {
             Attach(connected);
        }
       
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    // Called when attaching a FlowerComponent
    public void Attach(PlantComponent attachment)
    {

        connected=attachment;
        attachment.transform.parent=this.transform;
        connected.transform.position = this.transform.position;
        connected.transform.rotation = this.transform.rotation;

        
    }
}
