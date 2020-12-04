using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using InventorySystem;

namespace Collectibles
{
    public class CollectibleManager : MonoBehaviour
    {
        [Header("Settings")]
        public bool debug = true;
        [Range(0.8f, 3f)]
        public float holdTime = 0.8f;
        private float holdTimer = 0f;
        /*[Range(1f, 6f)]
        public float lifetime = 5f;
        private int lifetimeTimer = 0;*/

        public List<GameObject> collectiblePool;
        private InventoryManager inventory;

        [Space(10f)]
        public UnityEvent onHold;

        private List<GameObject> collectiblesToDelete = new List<GameObject>();

        void Start()
        {
            inventory = GameObject.Find("Inventory Manager").GetComponent<InventoryManager>();
        }

        void Update()
        {
            //Si un collectible à disparu, l'enlève de la liste
            //UpdateCollectibleList();

            //InputCheck si le joueur Hold Tap
            //HoldTimerIncrement();

            //CollectiblesLifetime();

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
            foreach(GameObject collectible in collectiblePool)
            {
                //Ajoute 1 à l'inventaire
                inventory.AddRessources(collectible.GetComponent<Collectible>().couleur, 1);

                //Ajoute le collectible à la liste des objets à delete
                collectiblesToDelete.Add(collectible);
            }


            if (debug) Debug.Log("Les cristaux ont été ramassés !");
        }
        
        private void UpdateCollectibleList()
        {
            foreach (GameObject collectible in new List<GameObject>(collectiblePool))
            {
                if (!collectible)
                {
                    if (debug) Debug.Log("On a une référence à un cristal fantôme, débarassons-nous en !");
                    collectiblesToDelete.Add(collectible);
                }
            }

            collectiblePool.RemoveAll(collectible => collectiblesToDelete.Contains(collectible));
        }

        /*private void CollectiblesLifetime()
        {
            lifetimeTimer += Time.deltaTime;
            if(lifetimeTimer >= lifetime && !(collectiblePool.Count == 0))
            {
                if (debug) Debug.Log("Le lifeTime des cristaux à été dépassé !");

                foreach (GameObject collectible in collectiblePool)
                {
                    collectiblesToDelete.Add(collectible);
                }

                StartCoroutine(DeleteCollectiblesToDelete());
            }
        }*/

        /*private IEnumerator DeleteCollectiblesToDelete()
        {
            if (debug) Debug.Log("Les cristaux sont en plan depuis trop longtemps, ils sont détruits");
            foreach (GameObject collectibles in collectiblesToDelete)
            {
                Destroy(collectibles);
                yield return new WaitForSeconds(0.5f);
            }
        }*/
    }
}