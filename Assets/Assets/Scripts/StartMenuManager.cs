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
        button.onClick.AddListener(updateScene);
    }

    // Update is called once per frame
    void Update()
    {
       



    }

    void updateScene()
    {
       // SceneManager.LoadScene("SampleScene");
    }
}
