using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PotionCreationSystem
{

    public class PotionCreation : MonoBehaviour
    {
        public List<Potions> listeDesPotions;
        [Space(10f)]
        public Potions defaultPot;
        public PotionBocaux[] bocaux = new PotionBocaux[3];

        private int ingredientsAlikeCount;
        private Potions potionFound = null;

        private List<Potions.Ingredients> ingredients = new List<Potions.Ingredients>();
        

        // Start is called before the first frame update
        void Start()
        {
            print("crafted : " + WhichPotionToCraft().text);
        }

        // Update is called once per frame
        void Update()
        {

        }

        //Fait le tour de la liste de potions disponibles pour déterminer s'il en existe une avec la combinaison actuelle
        public Potions  WhichPotionToCraft()
        {
            ingredientsAlikeCount = 0;

            foreach(Potions potion in listeDesPotions)
            {
                foreach(Potions.Ingredients i in potion.listeIngredients)
                {
                    ingredients.Add(i);
                }
                //ingredients = potion.listeIngredients;

                //Si une potion compatible à été trouvée, sors de la boucle 
                if (potionFound != null)
                {
                    return potionFound;
                }


                //Compare les ingrédients dans les bocaux à la potion actuelle
                foreach (PotionBocaux bocal in bocaux)
                {
                    print("Igrédient dans le bocal n° " + bocal.bocalIndex + " = " + bocal.currentIngredient);

                    if(ingredients.Contains(bocal.currentIngredient))
                    {
                        ingredients.Remove(bocal.currentIngredient);
                        ingredientsAlikeCount++;
                    }
                }
                if (ingredientsAlikeCount == 3)
                {
                    potionFound = potion;
                }
                else
                {
                    ingredientsAlikeCount = 0;

                }

            }

            if(potionFound == null) potionFound = defaultPot;

            return potionFound;
        }

    }
}
