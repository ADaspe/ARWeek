using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryColor : MonoBehaviour
{

    //public ColorQuantity emptyPotion = new ColorQuantity(10, Color.clear);
    public ColorQuantity[] colorPotions;

    [Serializable]
    public struct ColorQuantity
    {
        public int quantity;
        public Color color;
        
        public ColorQuantity(int cqQuantitiy, Color cqColor)
        {
            quantity = cqQuantitiy;
            color = cqColor;
        }
    }

}
