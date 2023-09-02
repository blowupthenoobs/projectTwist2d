using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


   public TileManager TileManager;
   public GameObject DeathScreen;
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
        
    }

    public void Die()
    {
        DeathScreen.SetActive(true);
    }
}
