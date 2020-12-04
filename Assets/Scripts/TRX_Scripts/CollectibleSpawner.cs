using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PotionCreationSystem;
using InventorySystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


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
        public float profondeur = 30f;
        public ARSessionOrigin ARSessionOrigin;
        public Camera ARCamera;

        private Transform newLocation;

        [Header("Collectibles")]
        public Collectible redColl;
        public Collectible blueColl;
        public Collectible greenColl;
        public Collectible pinkColl;
        public Collectible blackColl;
        public Collectible whiteColl;

        private Collectible collToSpawn;
        private Collectible collSpawned;
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

        private void CollectibleSpawn(Collectible toSpawn)
        {
            //Transform spawn = SpawnLocation();
            /*GameObject go2 = Instantiate(toSpawn) as GameObject;
            go2.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 1f;*/
            collSpawned = Instantiate(toSpawn);
            collSpawned.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 200f + new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), profondeur);
            //ARSessionOrigin.MakeContentAppearAt(collSpawned.transform, spawn.position);
            //Demander à Alexis comment on fait pour faire spawner un truc en face de la caméra
            if (debug) print("Collectible Spawned !");
            collManagerScript.collectiblePool.Add(collSpawned);
        }
        /*private Transform SpawnLocation()
        {
            
            if (debug) print("Randomisation de la Localisation..."); 
            Debug.Log(ARCamera.transform.position + ARCamera.transform.forward * 2f);
            newLocation.position = ARCamera.transform.position + ARCamera.transform.forward * 2f;
            Debug.Log("ça marche ici ?");
            newLocation.position += new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), profondeur);
            Debug.Log("X : " + newLocation.position.x + " Y : " + newLocation.position.y + " Z : " + newLocation.position.z);
            return newLocation;
        }*/

    }

}


