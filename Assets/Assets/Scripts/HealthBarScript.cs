using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Image HealthBar;
    public GameObject Player;
    public float playerHealth;
    private float playerMaxHealth;
    public float transitionSpeed;

    void Update()
    {
        playerHealth=Player.GetComponent<Player>().hp;
        playerMaxHealth=Player.GetComponent<Player>().maxhp;

        HealthBar.fillAmount=Mathf.Lerp(HealthBar.fillAmount, playerHealth/playerMaxHealth, transitionSpeed);
    }
}
