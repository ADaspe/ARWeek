using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PotionCreationSystem
{

    public class PotionScript : MonoBehaviour
    {
        public Image potionImage;
        public List<Image> ingredientImages;
        public Potions potions;

        private void Start()
        {
            potionImage.sprite = potions.Icon;
            potionImage.enabled = false;
            foreach (Image image in ingredientImages)
            {
                image.enabled = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (potions.isCrafted)
            {
                potionImage.enabled = true;
                foreach (Image image in ingredientImages)
                {
                    image.enabled = true;
                }
                

            }
        }
    }

}