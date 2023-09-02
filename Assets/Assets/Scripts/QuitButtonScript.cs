using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("You Can't Quit in Unity! Mwhahahahahaha!");
    }
}
