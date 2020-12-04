using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnPage : MonoBehaviour
{
    public GameObject previousPage;
    public GameObject nextPage;
    public Button buttonNext;
    public Button buttonPrevious;
    // Start is called before the first frame update
    void Start()
    {
        if (buttonNext)
        {
            buttonNext.onClick.AddListener(() => Next());
        }
        if (buttonPrevious)
        {
            buttonPrevious.onClick.AddListener(() => Previous());
        }
    }

    public void Next()
    {
        nextPage.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void Previous()
    {
        previousPage.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
