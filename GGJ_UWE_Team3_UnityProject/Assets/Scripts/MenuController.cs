using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject OptionsOverlay;

    public void PlayGame()
    {
        SceneManager.LoadScene("Game-Level1");
    }

    public void Options()
    {
        OptionsOverlay.SetActive(true);
    }

    public void Close()
    {
        OptionsOverlay.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
