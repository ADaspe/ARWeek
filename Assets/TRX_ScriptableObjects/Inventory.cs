using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(fileName = "Inventory", menuName = "InventoryMaster", order = 1)]
    public class Inventory : ScriptableObject
    {
        [Header ("Collectibles")]
        public int Red = 0;
        public int Pink = 0;
        public int Green = 0;
        public int Blue = 0;
        public int Black = 0;
        public int White = 0;

        [Header("Fioles")]
        public int maxFioles = 10;

    }
}
