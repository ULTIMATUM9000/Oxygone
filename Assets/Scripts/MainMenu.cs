using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        PlayerPrefs.SetFloat("CurrentScore", 0);
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!!!");
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
