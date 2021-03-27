using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlantComponent : MonoBehaviour
{
    [SerializeField] public const int GROWTHSTAGES = 10;
    [SerializeField] private bool DebugTriggerGrowthstage;
    [SerializeField] private int DebugGrowAmount;
    [SerializeField] private bool DebugTriggerActivation;

    [SerializeField] private Fighter DebugTestTarget;
    [SerializeField] private bool DebugTriggerMerge;
    [SerializeField] private PlantComponent DebugTestMerge;

    [SerializeField] private int _growthStage = 0;

    public void Initialize()
    {
        _growthStage = 0;
        this.gameObject.transform.localScale = new Vector3(0,0,0);
    }
    public void UpdateGrowth(int growthAmount)
    {
        Debug.Log("imgrooooowing "+growthAmount.ToString());
        _growthStage += growthAmount;
        
        if (_growthStage > GROWTHSTAGES)
        {
            Debug.Log("yepper");
       
            foreach (PlantComponent nextComponent in this.GetChildPlantComponents())
            {
                Debug.Log("nextComponent.ToString()");
                nextComponent.UpdateGrowth(_growthStage-GROWTHSTAGES);
            }
            //hacksolution for updating attached plant transforms. attach updates attached components transform to its own position
            foreach (SnapPoint snapperino in this.GetSnapPoints())
            {
                snapperino.Attach(snapperino.getConnectedPlantComponent());
            }
            _growthStage = GROWTHSTAGES;
            
        }
        float scalemult = (float)_growthStage/GROWTHSTAGES;
        Debug.Log(scalemult.ToString()+GROWTHSTAGES.ToString());
        this.gameObject.transform.localScale = new Vector3(scalemult,scalemult,scalemult); 
    }
    //Returns true if this plantcomponent and all children have their growth set to maxgrowth
    public bool IsFullyGrown()
    {
        bool recursiveCheck = true;
        foreach (PlantComponent checkItem in this.GetChildPlantComponents())
        {
            if (checkItem.IsFullyGrown()==false)
            {
                recursiveCheck = false;
                break;
            }
        }
        return ((_growthStage==GROWTHSTAGES) && (recursiveCheck));
    }
    public virtual List<SnapPoint> GetSnapPoints()
    {
        throw new System.Exception("Error: calling undefined GetSnapPoints method");
    }
    public List<PlantComponent> GetChildPlantComponents()
    {
        List<PlantComponent> templist = new List<PlantComponent>();
        Debug.Log("wof");
        foreach (SnapPoint currentPoint in this.GetSnapPoints())
        {
            Debug.Log("mof");
            templist.Add(currentPoint.getConnectedPlantComponent());
        }
        return templist;
    }


    public PlantComponent Breed(PlantComponent partner)
    {
        PlantComponent babby;
        int geneticDeviation = Random.Range(0,10);
        List<PlantComponent> genePool = new List<PlantComponent>();
        foreach (SnapPoint gene in this.GetSnapPoints())
        {
           genePool.Add(gene.getConnectedPlantComponent()); 
        } 
        foreach (SnapPoint gene in partner.GetSnapPoints())
        {
           genePool.Add(gene.getConnectedPlantComponent()); 
        } 
        switch (geneticDeviation)
        {
            case 1:
                babby = this;
                break;
            case 2:
                babby = partner;
                break;
            default:
                babby = this;
                break;
        }
        return babby;
    }

    virtual public string CardText(int intensity)
    {
        return "f";
    }

    virtual public void Activate(List<Fighter> target, int intensity)
    {

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public void DoSomeDebuggingNonsense()
    {
        
        //debugging functionality
        if (DebugTriggerGrowthstage)
        {
            DebugTriggerGrowthstage =false;
            this.UpdateGrowth(DebugGrowAmount);
        }
                if (DebugTriggerActivation)
        {
            List<Fighter> temptargetlist = new List<Fighter>();
            temptargetlist.Add(DebugTestTarget);
            DebugTriggerActivation = false;
            this.Activate(temptargetlist, 1);
            Debug.Log(this.CardText(1));
        }
        

    }

    // Update is called once per frame
    void Update()
    {

    }
}
