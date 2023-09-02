using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuStartScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text StartGame;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartGame.color = Color.green;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartGame.color = Color.black;
    }

        
    
}
