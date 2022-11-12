using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneControl : MonoBehaviour
{
    public bool TestingMode = true;
    public TextMeshProUGUI TestingText;

    public string MainMenuSceneName;
    public string MainGameSceneName;
    public string PauseSceneName;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == MainGameSceneName)
        {
            PauseGame();
        }

        if (SceneManager.sceneCount > 1)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(PauseSceneName));
        }
    }

    public void StartGame()
    {
        if (TestingMode)
        {
            TestingText.SetText("Scene Transition to Main Game");
        }
        else 
        {
            SceneManager.LoadScene(MainGameSceneName);
            SceneManager.LoadScene(PauseSceneName, LoadSceneMode.Additive);
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
            Application.Quit();
        }
    }

    public void PauseGame()
    {
        //SceneManager.LoadScene(PauseSceneName, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(PauseSceneName));
    }

    public void ResumeFromPause()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(MainGameSceneName));
        //SceneManager.UnloadSceneAsync(PauseSceneName);
    }

    public void MainFromPause()
    {
        SceneManager.LoadScene(MainMenuSceneName, LoadSceneMode.Single);
    }
}