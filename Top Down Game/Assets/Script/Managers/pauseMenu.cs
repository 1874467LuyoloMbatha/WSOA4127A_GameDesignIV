using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject pausetheMenu;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pausetheMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();

            }
            else
            {
                PauseGame();
            }

        }
    }

    public void PauseGame()
    {
        pausetheMenu.SetActive(true);
        Time.timeScale = 0f;//pause action
        isPaused = true;
    }

    public void ResumeGame()
    {
        pausetheMenu.SetActive(false);
        Time.timeScale = 1f;//unpause action
        isPaused = false;
    }

    public void go2MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void qiutGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
