using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneControl : MonoBehaviour
{
    public bool TestingMode = true;
    public TextMeshProUGUI TestingText;

    public string MainGameSceneName;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        if (TestingMode)
        {
            TestingText.SetText("Scene Transition to Main Game");
        }
        else 
        {
            SceneManager.LoadScene("MainGame");
        }
    }

    public void QuitGame()
    {
        if (TestingMode)
        {
            TestingText.SetText("Exit Game");
        }
        else
        {
            
        }
    }
}
