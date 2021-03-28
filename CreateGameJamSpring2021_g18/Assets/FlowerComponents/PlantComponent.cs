using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class PlantComponent : MonoBehaviour
{
    [SerializeField] public const int GROWTHSTAGES = 10;
    private SnapPoint attachmentPoint;
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
        _growthStage += growthAmount;
        
        if (_growthStage > GROWTHSTAGES)
        {
       
            foreach (PlantComponent nextComponent in this.GetChildPlantComponents())
            {
                nextComponent.UpdateGrowth(_growthStage-GROWTHSTAGES);
            }
            //hacksolution for updating attached plant transforms. attach updates attached components transform to its own position
            foreach (SnapPoint snapperino in this.GetSnapPoints())
            {
                snapperino.Attach();
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
        Debug.Log("Inside get childrens");
        List<PlantComponent> templist = new List<PlantComponent>();
        foreach (SnapPoint currentPoint in this.GetSnapPoints())
        {
            templist.Add(currentPoint.getConnectedPlantComponent());
            Debug.Log("Made it through "+currentPoint.ToString());
        }
        Debug.Log("exiting getchildcomponents "+templist.Count.ToString());
        return templist;
    }


    public PlantComponent Breed(PlantComponent partner)
    {
        List<PlantComponent> dnaListPartner = partner.GetDna();
        
        PlantComponent returnComponent = Instantiate(this);
        
        List<PlantComponent> dnaListSelf = returnComponent.GetDna();
        int indexSelfList = Random.Range(0,(dnaListSelf.Count));
        int indexPartnerList = Random.Range(0,(dnaListPartner.Count));

        List<SnapPoint> mutationPointList = new List<SnapPoint>();
        Debug.Log("Snappingpoints: "+indexSelfList.ToString());
        mutationPointList = dnaListSelf[indexSelfList].GetSnapPoints();
        Debug.Log("time for muties?"+mutationPointList.Count.ToString());
        if (mutationPointList.Count >= 1)
        {
            Debug.Log("doin mutatin"+mutationPointList.Count.ToString()+" /// "+dnaListPartner.Count.ToString()+" /// "+dnaListSelf.Count.ToString());
            int indexSnapList = Random.Range(0,mutationPointList.Count);
            PlantComponent mutation = Instantiate(dnaListPartner[indexPartnerList]);
            PlantComponent dead = mutationPointList[indexSnapList].getConnectedPlantComponent();
            Debug.Log("dead is "+dead.ToString());
            mutationPointList[indexSnapList].Attach(mutation);
            Destroy(dead.gameObject);
            
        }
        
        return returnComponent;
    }
    public List<PlantComponent> GetDna()
    {
        List<PlantComponent> templist = new List<PlantComponent>();
        Debug.Log("Did it");
        foreach (PlantComponent item in this.GetChildPlantComponents())
        {
            Debug.Log("madeitinside" + item.ToString());
            templist.AddRange(item.GetDna());
        }
        Debug.Log("madeitthrough");
        templist.Add(this);
        Debug.Log("templist :"+templist.ToString());
        return templist;
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
        if (DebugTriggerMerge)
        {
            DebugTriggerMerge = false;
            this.Breed(DebugTestMerge);
        }
        

    }

    // Update is called once per frame
    void Update()
    {

    }
}
