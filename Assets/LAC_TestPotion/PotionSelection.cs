using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionSelection : MonoBehaviour
{
    public InventoryColor m_InventoryColor;
    public bool lockSelection;

    public int[] potionIndex = { 0, 0, 0 } ;
    public int[,] potionQntyModifier = new int[7,3];
    [SerializeField]
    int[] totalQntyModifier = new int[7];
    [SerializeField]
    int[] finalColorQuantity = new int[7];
    

    //public Color colorToReturn = Color.clear;

    public Button[] m_Buttons;
    public Image[] m_Images;

    public Light[] lightPotion;
    public GameObject[] blackSolid;

    private void Start()
    {
        potionQntyModifier = new int[m_InventoryColor.colorPotions.Length, potionIndex.Length];
        totalQntyModifier = new int[m_InventoryColor.colorPotions.Length];

        for(int b = 0; b < m_Buttons.Length; b++)
        {
            Button m_Button = m_Buttons[b];
            int vesselIndex = (int)(b/2);

            if(b%2 == 0)
                m_Button.onClick.AddListener(() => ColorSelectionL(vesselIndex));
            else
                m_Button.onClick.AddListener(() => ColorSelectionR(vesselIndex));
        }
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
            int currentPotionQuantity = m_InventoryColor.colorPotions[potionIndex[vesselIndex]].quantity + totalQntyModifier[potionIndex[vesselIndex]];
            if (currentPotionQuantity < 0)
            {
                potionIndex[vesselIndex]--;
                // verify range index
                potionIndex[vesselIndex] = (potionIndex[vesselIndex] < 0) ? numberOfColor - 1 : (potionIndex[vesselIndex]) % numberOfColor;
            }
        }
        
    }
}
