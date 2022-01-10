using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPauseController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionMenu;
    private bool isPause;
    private void Awake()
    {
        isPause = false;
    }
    private void Start()
    {
        pauseMenu.SetActive(false);
        optionMenu.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            interactPauseMenu();
        }
    }
    public void interactPauseMenu()
    {
        if (isPause)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
        isPause = !isPause;
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }
    public void interactOptionMenu()
    {
        optionMenu.SetActive(!optionMenu.activeSelf);
    }
    public void resume()
    {
        interactPauseMenu();
    }
    public void quit()
    {
        Application.Quit();
    }
}
