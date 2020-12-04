using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PotionCreationSystem;
using InventorySystem;

namespace Collectibles
{
    public class Collectible : MonoBehaviour
    {
        public Animator animator;
        public Potions.Ingredients couleur = Potions.Ingredients.EMPTY;

    }
}
