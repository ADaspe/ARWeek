using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PotionCreationSystem
{
    [CreateAssetMenu(fileName = "newPotion", menuName = "Potion", order = 0)]
    public class Potions : ScriptableObject
    {
        public enum Ingredients { EMPTY, BLUE, GREEN, RED, PINK, WHITE, BLACK };
        

        [Header("Paramètres")]
        public int index;
        [Space(10f)]
        public string text;
        public Sprite Icon;
        [TextArea]
        public string description;
        [Range(0f, 300f)]
        public float tempsDeLaRecette = 60f;
        public bool isCrafted;

        [Header("Ingrédients")]
        public List<Ingredients> listeIngredients;

    }
}
