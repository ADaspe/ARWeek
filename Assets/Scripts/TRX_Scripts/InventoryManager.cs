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


        public bool AddRessources(Potions.Ingredients couleur, int nbr)
        {
            Debug.Log("Nbr : " + nbr);
            if (inventoryMaster.canAddColor(nbr))
            {
                if (couleur == Potions.Ingredients.RED)
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
                return true;
            }
            else
            {
                if (debug) print("Plus de place !");
                return false;
            }
            
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
