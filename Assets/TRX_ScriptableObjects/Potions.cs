using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PotionCreationSystem
{
    [CreateAssetMenu(fileName = "newPotion", menuName = "Potion", order = 0)]
    public class Potions : ScriptableObject
    {
        public enum Ingredients { EMPTY, BLUE, GREEN, RED, PINK, WHITE, BLACK };
        
        public Ingredients Ingredient;

        [Header("Paramètres")]
        public int index;
        [Space(10f)]
        public string text;
        public Sprite Icon;
        [Range(0f, 300f)]
        public float tempsDeLaRecette = 60f;

        [Header("Ingrédients")]
        public List<Ingredients> listeIngredients;

    }
}
