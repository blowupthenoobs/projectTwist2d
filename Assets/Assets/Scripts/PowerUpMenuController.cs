using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMenuController : MonoBehaviour
{
    public GameObject powerUpMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        display();
    }

    public void display()
    {
        if (Input.GetKeyDown(KeyCode.F)) {
            powerUpMenu.SetActive(!powerUpMenu.active); }
        
    }
}
