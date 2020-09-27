using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuFB : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    

    public void Pause()
    {
       _pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
      _pauseMenu.SetActive(false);
       Time.timeScale = 1f;
    }

    public void Restart()
    {
      _pauseMenu.SetActive(false);
       SceneManager.LoadScene("Flappy Bird");
       Time.timeScale = 1f;
    }

    public void MainMenu()
    {
      SceneManager.LoadScene("Main Menu");
    }

    
}
