using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapPoint : MonoBehaviour
{
    [SerializeField] private PlantComponent connected = null;
        [SerializeField] private bool DebugAddComponent;
        [SerializeField] private GameObject DebugComponentToAdd;

    // Start is called before the first frame update
    public PlantComponent getConnectedPlantComponent()
    {
        if (connected == null)
        {
            Debug.Log("CONNECTED IS NULL");
        }
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
        if (DebugAddComponent)
        {
            DebugAddComponent = false;
            this.Attach();
        }

        
    }

    // Called when attaching a FlowerComponent

    public void Attach()
    {
        if (connected == null)
        {
            if (DebugComponentToAdd != null)
            {
                GameObject temp = Instantiate(DebugComponentToAdd,this.transform,true) as GameObject;
                connected = temp.GetComponent<PlantComponent>();
            }
        }
        else
        {
            connected.transform.position=this.transform.position;
        }

    }
    public void Attach(PlantComponent attachment)
    {

        connected=attachment;
        attachment.transform.parent=this.transform;
        connected.transform.position = this.transform.position;
        connected.transform.rotation = this.transform.rotation;

        
    }
}
