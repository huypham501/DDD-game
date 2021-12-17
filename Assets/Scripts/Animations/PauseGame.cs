using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public static bool gameIsPaused = false;
    void Update()
    {
    }
    public void Pause()
    {
        if (gameIsPaused == false)
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;
            gameIsPaused = true;
            Debug.Log("Game is Pause");
        }
        else
        {
            Time.timeScale = 1f;
            AudioListener.pause = false;
            gameIsPaused = false;
            Debug.Log("Game is Resume");
        }
    }

}