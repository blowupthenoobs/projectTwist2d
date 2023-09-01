using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoonTimer : MonoBehaviour
{
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
        if (moonSlider.value >= 60)
        {
            startNightTransition();
        }
    }

    private void startNightTransition()
    {
        throw new NotImplementedException();
    }

 
}
