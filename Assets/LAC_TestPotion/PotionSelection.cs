using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InventorySystem;
using PotionCreationSystem;

public class PotionSelection : MonoBehaviour
{
    public Inventory m_Inventory;
    public InventoryColor m_InventoryColor;
    public GameObject potionTimer;
    public PotionTimerUI uiTimer;

    public bool lockSelection;

    public int[] potionIndex = { 0, 0, 0 } ;
    public int[,] potionQntyModifier = new int[7,3];
    [SerializeField]
    int[] totalQntyModifier = new int[7];
    [SerializeField]
    int[] finalColorQuantity = new int[7];


    //public Color colorToReturn = Color.clear;
    public Button craftButton;
    public Button[] selectButton;
    public Image[] m_Images;

    public Light[] lightPotion;
    public GameObject[] blackSolid;

    public PotionCreation m_PotionCreation;
    public PotionBocaux[] potionsBocaux;

    private void Start()
    {
        potionQntyModifier = new int[m_InventoryColor.colorPotions.Length, potionIndex.Length];
        totalQntyModifier = new int[m_InventoryColor.colorPotions.Length];

        for(int b = 0; b < selectButton.Length; b++)
        {
            Button m_Button = selectButton[b];
            int vesselIndex = (int)(b/2);

            if(b%2 == 0)
                m_Button.onClick.AddListener(() => ColorSelectionL(vesselIndex));
            else
                m_Button.onClick.AddListener(() => ColorSelectionR(vesselIndex));
        }
        craftButton.onClick.AddListener(ApplyCraft);
     
    }

    private void Update()
    {
        /*int numberOfColor = m_InventoryColor.colorPotions.Length;
        potionIndex = (potionIndex <0)? numberOfColor-1 : (potionIndex) % numberOfColor;
        
        // ok good
        if(m_InventoryColor.colorPotions[potionIndex].quantity <= 0)
            potionIndex++;
        
        potionIndex = (potionIndex < 0) ? numberOfColor - 1 : (potionIndex) % numberOfColor;

        colorToReturn = m_InventoryColor.colorPotions[potionIndex].color;
        m_Image.color = colorToReturn;*/

        int numberOfColor = m_InventoryColor.colorPotions.Length;

        // increment index selection
        for (int v = 0; v < potionIndex.Length; v++)
        {
            potionIndex[v] = (potionIndex[v] < 0) ? numberOfColor - 1 : (potionIndex[v]) % numberOfColor;

            // skip slection with no potion
            /*int currentPotionQuantity = m_InventoryColor.colorPotions[potionIndex[v]].quantity + totalQntyModifier[potionIndex[v]];
            if (currentPotionQuantity < 0)
            {
                potionIndex[v]++;
                // verify range index
                potionIndex[v] = (potionIndex[v] < 0) ? numberOfColor - 1 : (potionIndex[v]) % numberOfColor;
            }*/

            // assign color
            Color colorToReturn = m_InventoryColor.colorPotions[potionIndex[v]].color;

            m_Images[v].color = colorToReturn;
            lightPotion[v].color = colorToReturn;

            blackSolid[v].SetActive((colorToReturn == m_InventoryColor.colorPotions[6].color));

            // update quantity modifier
            
            for(int p = 0; p < numberOfColor; p++)
            {
                if (p == potionIndex[v] && p!= 0)
                    potionQntyModifier[p,v] = -1;
                else
                    potionQntyModifier[p, v] = 0;

                totalQntyModifier[p] = potionQntyModifier[p, 0] + potionQntyModifier[p, 1] + potionQntyModifier[p, 2];
                finalColorQuantity[p] = totalQntyModifier[p] + m_InventoryColor.colorPotions[p].quantity;
            }
        }
    }
    public void ColorSelectionL( int vesselIndex)
    {
        if (!lockSelection)
        {
            int numberOfColor = m_InventoryColor.colorPotions.Length;

            potionIndex[vesselIndex]++;
            potionIndex[vesselIndex] = (potionIndex[vesselIndex] < 0) ? numberOfColor - 1 : (potionIndex[vesselIndex]) % numberOfColor;
            int currentPotionQuantity = m_InventoryColor.colorPotions[potionIndex[vesselIndex]].quantity + totalQntyModifier[potionIndex[vesselIndex]];
            if (currentPotionQuantity < 0)
            {
                potionIndex[vesselIndex]++;
                // verify range index
                potionIndex[vesselIndex] = (potionIndex[vesselIndex] < 0) ? numberOfColor - 1 : (potionIndex[vesselIndex]) % numberOfColor;
            }
        }
       
    }

    public void ColorSelectionR(int vesselIndex)
    {
        if (!lockSelection)
        {
            int numberOfColor = m_InventoryColor.colorPotions.Length;

            potionIndex[vesselIndex]--;
            potionIndex[vesselIndex] = (potionIndex[vesselIndex] < 0) ? numberOfColor - 1 : (potionIndex[vesselIndex]) % numberOfColor;
            int currentPotionQuantity = m_InventoryColor.colorPotions[potionIndex[vesselIndex]].quantity + totalQntyModifier[potionIndex[vesselIndex]];
            if (currentPotionQuantity < 0)
            {
                potionIndex[vesselIndex]--;
                // verify range index
                potionIndex[vesselIndex] = (potionIndex[vesselIndex] < 0) ? numberOfColor - 1 : (potionIndex[vesselIndex]) % numberOfColor;
            }
        }
    }

    public void ApplyCraft()
    {
        Debug.Log("craft");
        // setup potion bocaux
        int numberOfColor = m_InventoryColor.colorPotions.Length;
        for (int i = 0; i < potionsBocaux.Length; i++)
        {
            Potions.Ingredients currIngredient = Potions.Ingredients.EMPTY;
            for (int c = 0; c < numberOfColor; c++)
            {
                if(potionQntyModifier[c,i] != 0)
                {
                    if (c == 1) currIngredient = Potions.Ingredients.RED;
                    if (c == 2) currIngredient = Potions.Ingredients.BLUE;
                    if (c == 3) currIngredient = Potions.Ingredients.GREEN;
                    if (c == 4) currIngredient = Potions.Ingredients.PINK;
                    if (c == 5) currIngredient = Potions.Ingredients.WHITE;
                    if (c == 6) currIngredient = Potions.Ingredients.BLACK;
                }
            }
            potionsBocaux[i].currentIngredient = currIngredient;

        }

        Potions potionToCraft = m_PotionCreation.WhichPotionToCraft();
        print("La potion craftée : "+ potionToCraft.text);
        uiTimer.SetPotion(potionToCraft);

        // apply color quantity to inventory
        m_Inventory.Red = finalColorQuantity[1];
        m_Inventory.Blue = finalColorQuantity[2];
        m_Inventory.Green = finalColorQuantity[3];
        m_Inventory.Pink = finalColorQuantity[4];
        m_Inventory.White = finalColorQuantity[5];
        m_Inventory.Black = finalColorQuantity[6];

        // reset bocaux
        for (int i = 0; i < potionsBocaux.Length; i++)
        {
            potionsBocaux[i].currentIngredient = Potions.Ingredients.EMPTY; 
            potionIndex[i] = 0;
        }

        //potionTimer.SetActive(true);
    }
}
