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
        public bool debug = true;
        public float lifetime;
        private float lifetimeTimer = 0f;
        private void Update()
        {
            CollectiblesLifetime();
        }

        private void CollectiblesLifetime()
        {
            lifetimeTimer += Time.deltaTime;
            if (lifetimeTimer >= lifetime)
            {
                if (debug) Debug.Log("Le lifeTime des cristaux à été dépassé !");

                Destroy(gameObject);
            }
        }
    }
}
