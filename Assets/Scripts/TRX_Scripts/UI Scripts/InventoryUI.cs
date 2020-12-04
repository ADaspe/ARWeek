using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Collectibles;
using InventorySystem;

public class InventoryUI : MonoBehaviour
{

    [Header("Settings")]
    public bool debug = true;
    [Space(10f)]
    public Inventory inventoryMaster;
    [Space(10f)]
    public Text redNbrField;
    public Text greenNbrField;
    public Text blueNbrField;
    public Text pinkNbrField;
    public Text whiteNbrField;
    public Text blackNbrField;
    [Space(5f)]
    public Text fiolesField;

    private void Update()
    {
        UpdateGraphics();
    }
    private void UpdateGraphics()
    {
        int nbrFioles = (inventoryMaster.maxFioles - (inventoryMaster.Red + inventoryMaster.Blue + inventoryMaster.Green + inventoryMaster.Black + inventoryMaster.Pink + inventoryMaster.White));
            //
        redNbrField.text = inventoryMaster.Red.ToString();
        greenNbrField.text = inventoryMaster.Green.ToString();
        blueNbrField.text = inventoryMaster.Blue.ToString();
        pinkNbrField.text = inventoryMaster.Pink.ToString();
        whiteNbrField.text = inventoryMaster.White.ToString();
        blackNbrField.text = inventoryMaster.Black.ToString();
        fiolesField.text = nbrFioles.ToString();
    }

}
