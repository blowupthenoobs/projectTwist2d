using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoonTimer : MonoBehaviour
{
    public GameObject DayScreen;
    public GameObject NightScreen;
    public GameObject moonIcon;
    public GameObject sunIcon;
    public float TimeinDay;
    private float elapsedTime;
    private float startTime;
    public Slider timeSlider;
    public Image FillArea;
    public Color dayBarColor;
    public Color nightBarColor;
    private bool isday=true;

    void Start()
    {
        dayBarColor.a=1f;
        nightBarColor.a=1f;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime = Time.time-startTime;
        manageSlider();
    }

    private void manageSlider()
    {
        if(elapsedTime>=TimeinDay)
        {
            startTime=Time.time;
            timeSlider.value=0f;

            if(!isday)
            {
                startDayTransition();
            }
            else
            {
                startNightTransition();
            }
        }

        timeSlider.value = elapsedTime/TimeinDay;
    }

    private void startNightTransition()
    {
        DayScreen.SetActive(false);
        NightScreen.SetActive(true);
        moonIcon.SetActive(true);
        sunIcon.SetActive(false);
        FillArea.color = nightBarColor;
        isday=false;
    }
    private void startDayTransition()
    {
        DayScreen.SetActive(true);
        NightScreen.SetActive(false);
        moonIcon.SetActive(false);
        sunIcon.SetActive(true);
        FillArea.color = dayBarColor;
        isday=true;
    }

 
}
