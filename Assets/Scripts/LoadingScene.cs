using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Test2D");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuittButton()
    {
        Application.Quit();
    }
}
