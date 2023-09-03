using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuStartScript : MonoBehaviour
{
    // public TMP_Text StartGame;
    public void BeginGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // public void OnPointerEnter(PointerEventData eventData)
    // {
    //     StartGame.color = Color.green;
    // }

    // public void OnPointerExit(PointerEventData eventData)
    // {
    //     StartGame.color = Color.black;
    // }

        
    
}
