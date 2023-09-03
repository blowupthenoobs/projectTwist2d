using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoonTimer : MonoBehaviour
{
    public static MoonTimer Instance;

    public GameObject DayScreen;
    public GameObject NightScreen;
    public GameObject moonIcon;
    public GameObject sunIcon;
    public GameObject healthBar;
    public GameObject gun;
    public GameObject TileManager;
    public GameObject Spawner;
    public Animator playerAnimator;
    public float TimeinDay;
    private float elapsedTime;
    private float startTime;
    public Slider timeSlider;
    public Image FillArea;
    public Color dayBarColor;
    public Color nightBarColor;
    public bool isday=true;

    void Start()
    {
        dayBarColor.a=1f;
        nightBarColor.a=1f;
    }

    void Awake()
    {
        if(Instance==null)
            Instance=this;
        else
            Destroy(gameObject);
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
        healthBar.SetActive(true);
        gun.SetActive(true);
        FillArea.color = nightBarColor;
        isday=false;
        playerAnimator.SetBool("isNightTime", true);
        Spawner.SendMessage("IncreaseDifficulty");
    }
    private void startDayTransition()
    {
        DayScreen.SetActive(true);
        NightScreen.SetActive(false);
        moonIcon.SetActive(false);
        sunIcon.SetActive(true);
        healthBar.SetActive(false);
        gun.SetActive(false);
        FillArea.color = dayBarColor;
        TileManager.GetComponent<TileManager>().NewDay();
        isday=true;
        playerAnimator.SetBool("isNightTime", false);
    }

 
}
