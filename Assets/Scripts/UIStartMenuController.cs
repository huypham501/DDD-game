using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStartMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionMenu;
    void Start()
    {
        optionMenu.SetActive(false);
    }
    public void interactOptionMenu()
    {
        optionMenu.SetActive(!optionMenu.activeSelf);
    }
    public void interactMainMenu()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
    }
    public void play()
    {
        SceneManager.LoadScene("Scene_1_Cave");
    }
    public void quit()
    {
        Application.Quit();
    }
}
