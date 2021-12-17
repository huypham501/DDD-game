using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleRenderer : MonoBehaviour
{
    public GameObject pauseBox;
    void Start()
    {
        //pauseBox.SetActive(false);
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleVisibility();
        }
    }
    public void ToggleVisibility()
    {
        Renderer rend = gameObject.GetComponent<Renderer>();
        if (rend.enabled)
        {
            rend.enabled = false;
            //pauseBox.SetActive(false);
            Debug.Log("Turn off");
        }
        else
        {
            rend.enabled = true;
            //pauseBox.SetActive(true);
            Debug.Log("Turn on");
        }
    }

}
