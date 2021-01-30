using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject OptionsOverlay;

    private void Start()
    {
        
    }
    private void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("hit");
        SceneManager.LoadScene("Character");
    }

    public void Options()
    {
        OptionsOverlay.SetActive(true);
    }

    public void Back()
    {
        OptionsOverlay.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
