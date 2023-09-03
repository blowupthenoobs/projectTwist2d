using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoonTimer : MonoBehaviour
{
    public GameObject DayScreen;
    public GameObject NightScreen;
    public float timeUntilNextNightCycle;
    public Slider moonSlider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        manageSlider();
    }

    private void manageSlider()
    {
        moonSlider.value = (Time.time)/timeUntilNextNightCycle;
        if (moonSlider.value >=1)
        {
            startNightTransition();
        }
    }

    private void startNightTransition()
    {
        DayScreen.SetActive(false);
        NightScreen.SetActive(true);
    }

 
}
