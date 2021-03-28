using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CreateGameJam21.ItemDetails1;

namespace CreateGameJam21
{

    public class PopulateGrid : MonoBehaviour
    {
        public GameObject prefab;
        public int numberToCreate;
        public GameObject Inventory;
        public GameObject Deck;
        public GameObject Pot;

        void Start()
        {
            
            Inventory.transform.parent.transform.parent.gameObject.SetActive(false);
            Pot.transform.parent.transform.parent.gameObject.SetActive(false);
            Deck.transform.parent.transform.parent.gameObject.SetActive(false);
            Populate();
        }

        void Update()
        {

        }

        void Populate()
        {
            GameObject newObj;
            for (int i = 0; i < numberToCreate; i++)
            {
                newObj = (GameObject)Instantiate(prefab, transform);
                newObj.GetComponent<ItemDetails1>().number = i;
                newObj.GetComponent<Image>().color = Random.ColorHSV();
                newObj.GetComponent<ItemDetails1>().FindStuff(Inventory,Pot,Deck);
                GameManager.instance.Inventory.Add(newObj);
            }

        }
    }
}