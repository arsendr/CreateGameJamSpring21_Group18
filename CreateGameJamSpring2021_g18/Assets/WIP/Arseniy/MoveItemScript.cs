using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreateGameJam21
{
    public class MoveItemScript : MonoBehaviour
    {
        public GameObject prefab;

        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void MoveItem()
        {
            GameObject selectedObj;
            selectedObj = (GameObject)Instantiate(prefab, transform);
        }
    }
}
