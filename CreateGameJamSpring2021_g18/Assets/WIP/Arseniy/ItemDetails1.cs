using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CreateGameJam21
{


    public class ItemDetails1 : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject DefaultPlant;
        public int number;
        public GameObject Inventory;
        public GameObject Deck;
        public GameObject Pot;
        private GameObject InventoryGameObject;
        private GameObject PotGameObject;
        public bool isInventory = false;
        public bool isPot = false;

        void Start()
        {
            PotGameObject = GameObject.Find("FlowerPot");
        }

        public void FindStuff(GameObject I, GameObject P, GameObject D)
        {
            Inventory = I;
            Deck = D;
            Pot = P;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void DoIt()
        {/*
            if (Deck.activeInHierarchy)
            {
                if (transform.parent == Inventory.transform )
                {
                    if (GameManager.instance.Deck.Count < 10)
                    {
                        transform.parent = Deck.transform;
                        GameManager.instance.Inventory.Remove(this.gameObject);
                        GameManager.instance.Deck.Add(this.gameObject);
                    }
                }
                else if (transform.parent == Deck.transform)
                {
                    transform.parent = Inventory.transform;
                    GameManager.instance.Deck.Remove(this.gameObject);
                    GameManager.instance.Inventory.Add(this.gameObject);
                }
            }
            
            if (Pot.activeInHierarchy)
            {
                
                    if (transform.parent == Inventory.transform)
                    {
                        if (PotGameObject.GetComponent<Pot>().PotList.Count < 1)
                        {
                            transform.parent = Pot.transform;
                            GameManager.instance.Inventory.Remove(this.gameObject);
                            PotGameObject.GetComponent<Pot>().PotList.Add(this.gameObject);
                        }
                    }
                    else if (transform.parent == Pot.transform)
                    {
                        transform.parent = Inventory.transform;
                        GameManager.instance.Inventory.Add(this.gameObject);
                        PotGameObject.GetComponent<Pot>().PotList.Remove(this.gameObject);
                    }               
            }
            */
        }

        public void Plant()
        {
            Instantiate(DefaultPlant);
        }

    }
}