using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using InventorySystem;
using PotionCreationSystem;
using Collectibles;

public class PotionCompleteUI : MonoBehaviour
{

    [Header("Settings")]
    public bool debug = true;
    [Space(10f)]
    public Image potionIcon;
    [Space(10f)]
    public Text potionNTextField;
    public Text potionDescTextField;
    public Button validateButton;
    [Space(10f)]
    public Potions currentPotion = null;
    public UnityEvent onValidate;

    // Start is called before the first frame update
    void Start()
    {
        //UpdateGraphics();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateGraphics()
    {
        potionIcon.sprite = currentPotion.Icon;
        potionNTextField.text = currentPotion.text;
        potionDescTextField.text = "''" + currentPotion.description + "''";

    }

    public void SetPotion(Potions potion)
    {
        currentPotion = potion;
        UpdateGraphics();
;
    }
}
