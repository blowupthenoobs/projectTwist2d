using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartMenuManager : MonoBehaviour
{
    public Button button;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       



    }

    public void updateScene()
    {
       SceneManager.LoadScene("SampleScene");
    }
}
