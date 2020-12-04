using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using PotionCreationSystem;

namespace InventorySystem
{

    public class InventoryManager : MonoBehaviour
    {
        public Inventory inventoryMaster;

        public bool debug = true;

        /*public string redString = "Red";
        public string greenString = "Green";
        public string blueString = "Blue";
        public string blackString = "Black";
        public string pinkString = "Pink";
        public string whiteString = "White";*/
        
        
        //public UnityEvent addRessources;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void AddRessources(Potions.Ingredients couleur, int nbr)
        {
            if(couleur == Potions.Ingredients.RED)
            {
                inventoryMaster.Red += nbr;
            }
            if (couleur == Potions.Ingredients.GREEN)
            {
                inventoryMaster.Green += nbr;
            }
            if (couleur == Potions.Ingredients.BLUE)
            {
                inventoryMaster.Blue += nbr;
            }
            if (couleur == Potions.Ingredients.BLACK)
            {
                inventoryMaster.Black += nbr;
            }
            if (couleur == Potions.Ingredients.WHITE)
            {
                inventoryMaster.White += nbr;
            }
            if (couleur == Potions.Ingredients.PINK)
            {
                inventoryMaster.Pink += nbr;
            }

            if (debug) print("Ressources " + couleur + " ajoutée !");
        }

        public void SubRessources(Potions.Ingredients couleur, int nbr)
        {
            if (couleur == Potions.Ingredients.RED)
            {
                inventoryMaster.Red -= nbr;
            }
            if (couleur == Potions.Ingredients.GREEN)
            {
                inventoryMaster.Green -= nbr;
            }
            if (couleur == Potions.Ingredients.BLUE)
            {
                inventoryMaster.Blue -= nbr;
            }
            if (couleur == Potions.Ingredients.BLACK)
            {
                inventoryMaster.Black -= nbr;
            }
            if (couleur == Potions.Ingredients.WHITE)
            {
                inventoryMaster.White -= nbr;
            }
            if (couleur == Potions.Ingredients.PINK)
            {
                inventoryMaster.Pink -= nbr;
            }

            if (debug) print("Ressources " + couleur + " ajoutée !");
        }
    }

}
