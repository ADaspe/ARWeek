using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PotionCreationSystem;
using InventorySystem;


namespace Collectibles
{
    public class CollectibleSpawner : MonoBehaviour
    {
        [Header("Settings")]
        [Range(0.30f, 1f)]
        [Tooltip("Little delay before the next collectible spawns")]
        public float spawnDelay = 0.33f;
        private float delayTimer = 0;
        [Tooltip("Max nbr of Collectibles spawned at the same time")]
        public int maxCollectibles = 8;
        public bool debug = true;
        public Transform cameraMain;
        public float profondeur = 30f;

        private Transform newLocation;


        private int collCount;

        [Header("Collectibles")]
        public GameObject redColl;
        public GameObject blueColl;
        public GameObject greenColl;
        public GameObject pinkColl;
        public GameObject blackColl;
        public GameObject whiteColl;

        private GameObject collToSpawn;
        private GameObject collSpawned;
        private CollectibleManager collManagerScript;

        private void Start()
        {
            collManagerScript = gameObject.GetComponent<CollectibleManager>();
        }

        private void Update()
        {
            DelayBetweenSpawn();
        }

        private void DelayBetweenSpawn()
        {
            delayTimer += Time.deltaTime;

        }

        public void SpawnCollectibleOfColor(Potions.Ingredients couleur)
        {
            if (couleur == Potions.Ingredients.BLACK)
            {
                collToSpawn = blackColl;
                if (debug) print("Collectible de couleur : " + couleur + " a spawner");
                //Spawn le collectible
                CollectibleSpawn(collToSpawn);
            }
            else if (couleur == Potions.Ingredients.WHITE)
            {
                collToSpawn = whiteColl;
                if (debug) print("Collectible de couleur : " + couleur + " a spawner");

                CollectibleSpawn(collToSpawn);
            }
            else if (couleur == Potions.Ingredients.BLUE)
            {
                collToSpawn = blueColl;
                if (debug) print("Collectible de couleur : " + couleur + " a spawner");

                CollectibleSpawn(collToSpawn);
            }
            else if (couleur == Potions.Ingredients.GREEN)
            {
                collToSpawn = greenColl;
                if (debug) print("Collectible de couleur : " + couleur + " a spawner");

                CollectibleSpawn(collToSpawn);

            }
            else if (couleur == Potions.Ingredients.PINK)
            {
                collToSpawn = pinkColl;
                if (debug) print("Collectible de couleur : " + couleur + " a spawner");

                CollectibleSpawn(collToSpawn);
            }
            else
            {
                collToSpawn = redColl;
                if (debug) print("Collectible de couleur : " + couleur + " a spawner");

                CollectibleSpawn(collToSpawn);

            }

        }

        private void CollectibleSpawn(GameObject toSpawn)
        {
            collSpawned = Instantiate(toSpawn, SpawnLocation(), true);
            if (debug) print("Collectible Spawned !");
            collManagerScript.collectiblePool.Add(collSpawned);
            collCount++;
        }
        private Transform SpawnLocation()
        {
            if (debug) print("Randomisation de la Localisation...");
            newLocation = cameraMain;
            newLocation.position += new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), profondeur);
            return newLocation;
        }

    }

}


