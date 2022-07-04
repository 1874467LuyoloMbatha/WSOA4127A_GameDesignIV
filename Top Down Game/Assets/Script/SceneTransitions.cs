using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public void level1()
    {
        SceneManager.LoadScene(1);
    }
    public void level2()
    {
        SceneManager.LoadScene(2);
    }

    public void Controls()
    {
        SceneManager.LoadScene(3);
    }
    public void go2MainMenu()
    {
        //Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void qiutGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }

}
