using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


   public TileManager TileManager;
   public GameObject DeathScreen;
   public TMP_Text MoneyText;
   public int money;
    void Start()
    {
        TileManager = GetComponent<TileManager>();
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
        MoneyText.text = money.ToString();
    }

    public void GainMoney()
    {
        money++;
    }

    public void Die()
    {
        DeathScreen.SetActive(true);
        Time.timeScale=0f;
    }
}
