using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace InventorySystem
{

    public class InventoryManager : MonoBehaviour
    {
        public Inventory inventoryMaster;

        public string redString = "Red";
        public string greenString = "Green";
        public string blueString = "Blue";
        public string blackString = "Black";
        public string pinkString = "Pink";
        public string whiteString = "White";
        
        
        //public UnityEvent addRessources;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void AddRessources(string ressource, int nbr)
        {
            if(ressource == redString)
            {
                inventoryMaster.Red += nbr;
            }
            if (ressource == greenString)
            {
                inventoryMaster.Green += nbr;
            }
            if (ressource == blueString)
            {
                inventoryMaster.Blue += nbr;
            }
            if (ressource == blackString)
            {
                inventoryMaster.Black += nbr;
            }
            if (ressource == whiteString)
            {
                inventoryMaster.White += nbr;
            }
            if (ressource == pinkString)
            {
                inventoryMaster.Pink += nbr;
            }
        }

        public void SubRessources(string ressource, int nbr)
        {
            if (ressource == redString)
            {
                inventoryMaster.Red -= nbr;
            }
            if (ressource == greenString)
            {
                inventoryMaster.Green -= nbr;
            }
            if (ressource == blueString)
            {
                inventoryMaster.Blue -= nbr;
            }
            if (ressource == blackString)
            {
                inventoryMaster.Black -= nbr;
            }
            if (ressource == whiteString)
            {
                inventoryMaster.White -= nbr;
            }
            if (ressource == pinkString)
            {
                inventoryMaster.Pink -= nbr;
            }
        }
    }

}
