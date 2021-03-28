using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CreateGameJam21
{


    public class ItemDetails1 : MonoBehaviour
    {
        // Start is called before the first frame update
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
            InventoryGameObject = GameObject.Find("Inventory");
            InventoryGameObject.GetComponent<Inventory>().InventoryList.Add(this.gameObject);
            PotGameObject = GameObject.Find("Pot");
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
        {
            if (Deck.activeInHierarchy)
            {
                if (transform.parent == Inventory.transform)
                {
                    transform.parent = Deck.transform;
                    InventoryGameObject.GetComponent<Inventory>().InventoryList.Remove(this.gameObject);
                    InventoryGameObject.GetComponent<Inventory>().DeckList.Add(this.gameObject);

                }
                else if (transform.parent == Deck.transform)
                {
                    transform.parent = Inventory.transform;
                    InventoryGameObject.GetComponent<Inventory>().DeckList.Remove(this.gameObject);
                    InventoryGameObject.GetComponent<Inventory>().InventoryList.Add(this.gameObject);
                }
            }

            if (Pot.activeInHierarchy)
            {
                if (PotGameObject.GetComponent<Pot>().PotList.Count < 1)
                {
                    if (transform.parent == Inventory.transform)
                    {
                        transform.parent = Pot.transform;
                        InventoryGameObject.GetComponent<Inventory>().InventoryList.Remove(this.gameObject);
                        PotGameObject.GetComponent<Pot>().PotList.Add(this.gameObject);
                    }
                }
            }
            
        }

    }
}