using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateDeck : MonoBehaviour
{
    public int numberToCreate;
    public GameObject prefab;
    public GameObject Panel;
    public GameObject Deck;
    private GameObject PanelGameObject;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        PanelGameObject = GameObject.Find("CardsPanel");
        PanelGameObject.GetComponent<Panel>().CardsList.Add(this.gameObject);
        int i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Populate()
    {
        GameObject newObj;
            while (i <10)
            {
                newObj = (GameObject)Instantiate(prefab, transform);
                //newObj.GetComponent<CardDetails>().number = i;
                newObj.GetComponent<Image>().color = Random.ColorHSV();
                //newObj.GetComponent<CardDetails>().FindStuff(Deck);
                i++;
            }
    }

    public void PopulateSafe()
    {
        GameObject newObj;
        while (PanelGameObject.GetComponent<Panel>().CardsList.Count <10)
        {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<Image>().color = Random.ColorHSV();
            PanelGameObject.GetComponent<Panel>().CardsList.Add(newObj);
        }
    }

    public void DrawCards()
    {
        if (transform.parent == Panel.transform)
        {
            while (GameManager.instance.Deck.Count < 10)
            {
                GameManager.instance.Deck.Add(this.gameObject);
                PanelGameObject.GetComponent<Panel>().CardsList.Add(this.gameObject);
            }
        }
    }

    public void ClearDeck()
    {
        if (i == 10)
        {
            Debug.Log("Clear list");
            Transform panelTransform = GameObject.Find("CardsPanel").transform;
            foreach (Transform child in panelTransform)
            {
                Destroy(child.gameObject);
            }
            i = 0;
        }
    }
}
