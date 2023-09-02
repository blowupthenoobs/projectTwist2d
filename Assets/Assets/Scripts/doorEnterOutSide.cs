using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorEnterOutSide : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Hello");
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("InsideHouse");
        };
    }
}
