using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public TileManager TileManager;
    void Start()
    {
        TileManager = GetComponent<TileManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
