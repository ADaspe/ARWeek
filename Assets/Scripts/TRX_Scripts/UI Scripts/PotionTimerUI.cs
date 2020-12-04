using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using InventorySystem;
using PotionCreationSystem;
using Collectibles;

public class PotionTimerUI : MonoBehaviour
{
    [Header("Settings")]
    public bool debug = true;
    [Space(10f)]
    public Image icon1;
    public Image icon2;
    public Image icon3;
    [Space(10f)]
    public Text timerText;
    public Button validateButton;
    [Space(10f)]
    public Potions currentPotion;
    public UnityEvent onTimerCleared;


    [Header("Ingredients Icon")]
    public Sprite redIcon;
    public Sprite greenIcon;
    public Sprite blueIcon;
    public Sprite pinkIcon;
    public Sprite blackIcon;
    public Sprite whiteIcon;

    private float currentTimer;
    private float startTime;
    private float startTimer;
    private bool timerComplete = false;


    // Start is called before the first frame update
    void Start()
    {
        startTimer = currentPotion.tempsDeLaRecette;
        startTime = Time.time;
        UpdateGraphics();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    private void UpdateGraphics()
    {
        //Update la liste des ingrédients en fonction de la potion
        for(int i = 0; i < currentPotion.listeIngredients.Count; i++ )
        {
            print("L'item de la potion actuelle n° " + (i + 1) + " est de type " + currentPotion.listeIngredients[i]);

            if (currentPotion.listeIngredients[i] == Potions.Ingredients.BLACK)
            {
                if(i == 0)
                {
                    icon1.sprite = blackIcon;
                }
                else if(i == 1)
                {
                    icon2.sprite = blackIcon;

                }
                else
                {
                    icon3.sprite = blackIcon;
                }
            }
            else if (currentPotion.listeIngredients[i] == Potions.Ingredients.WHITE)
            {
                if (i == 0) icon1.sprite = whiteIcon;
                else if (i == 1) icon2.sprite = whiteIcon;
                else icon3.sprite = whiteIcon;

            }
            else if (currentPotion.listeIngredients[i] == Potions.Ingredients.GREEN)
            {
                if (i == 0) icon1.sprite = greenIcon;
                else if (i == 1) icon2.sprite = greenIcon;
                else icon3.sprite = greenIcon;
            }
            else if (currentPotion.listeIngredients[i] == Potions.Ingredients.BLUE)
            {
                if (i == 0) icon1.sprite = blueIcon;
                else if (i == 1) icon2.sprite = blueIcon;
                else icon3.sprite = blueIcon;
            }
            else if (currentPotion.listeIngredients[i] == Potions.Ingredients.RED)
            {
                if (i == 0) icon1.sprite = redIcon;
                else if (i == 1) icon2.sprite = redIcon;
                else icon3.sprite = redIcon;
            }
            else if (currentPotion.listeIngredients[i] == Potions.Ingredients.PINK)
            {
                if (i == 0) icon1.sprite = pinkIcon;
                else if (i == 1) icon2.sprite = pinkIcon;
                else icon3.sprite = pinkIcon;
            }
        }
    }

    private void UpdateTimer()
    {
        if (!timerComplete)
        {
            float timeSinceStarted = Time.time - startTime;
            currentTimer = startTimer - timeSinceStarted;
            string minutes = ((int)currentTimer / 60).ToString();
            string seconds = (currentTimer).ToString("f0");

            timerText.text = minutes + " : " + seconds;
            if(currentTimer <= 0f)
            {
                timerComplete = true;
            }
        }
        else
        {
            OnTimerComplete();
        }
    }

    private void OnTimerComplete()
    {
        if (onTimerCleared != null) onTimerCleared.Invoke();
    }

    public void SetPotion(Potions potion)
    {
        currentPotion = potion;
        startTimer = potion.tempsDeLaRecette;
        timerComplete = false;
    }


}
