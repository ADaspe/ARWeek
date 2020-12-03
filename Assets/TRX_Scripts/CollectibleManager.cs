using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Collectibles
{
    public class CollectibleManager : MonoBehaviour
    {
        [Header("Settings")]
        public bool debug = false;
        [Range(0.8f, 3f)]
        public float holdTime = 0.8f;
        private float holdTimer;
        [Range(0.30f, 1f)]
        [Tooltip("Little delay before the next collectible spawns")]
        public float spawnDelay = 0.33f;
        private float delayTimer = 0;
        [Tooltip("Max nbr of Collectibles spawned at the same time")]
        public int maxCollectibles = 8;

        public List<GameObject> collectiblePool;


        [Space(10f)]
        public UnityEvent onHold;

        private List<GameObject> collectiblesToDelete = new List<GameObject>();

        void Start()
        {

        }

        void Update()
        {
            //Si un collectible à disparu, l'enlève de la liste
            UpdateCollectibleList();

            //InputCheck si le joueur Simple Tap
            Tap();

            //InputCheck si le joueur Hold Tap
            HoldTimerIncrement();

        }

        private void HoldTimerIncrement()
        {
            if(Input.touchCount>0)
            {
                holdTimer += Input.GetTouch(0).deltaTime;
            }

            if (holdTimer >= holdTime)
            {
                //Se déclenche quand le joueur à effectué un HoldTap
                HoldTap();
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
                holdTimer = 0;
            }

        }

        //Invoke l'evenement onHold
        public void HoldTap()
        {
            if (onHold != null) onHold.Invoke();
            if (debug)
                Debug.Log("Les cristaux ont été ramassés !");
        }
        

        private void Tap()
        {
            if(Input.touchCount > 0)
            {
                //Fait Spawn un collectible qui correspond à la couleur
            }
        }
        private void UpdateCollectibleList()
        {
            foreach (GameObject collectible in new List<GameObject>(collectiblePool))
            {
                if (!collectible)
                {
                    Debug.Log("Enemy missing from scene, add it to the list of enemy to delete from enemy list");
                    collectiblesToDelete.Add(collectible);
                }
            }

            collectiblePool.RemoveAll(collectible => collectiblesToDelete.Contains(collectible));
        }
    }
}