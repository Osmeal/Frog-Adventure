using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class UIManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public AudioSource sound;
    public GameObject transition;
    public void OptionsPanel()
    {
        Time.timeScale = 0;
        optionsPanel.SetActive(true);
        sound.Play();
    }

    public void Return()
    {
        Time.timeScale = 1;
        optionsPanel.SetActive(false);
        sound.Play();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        transition.SetActive(true);
        Invoke("ChangeScene", 0.7f);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
