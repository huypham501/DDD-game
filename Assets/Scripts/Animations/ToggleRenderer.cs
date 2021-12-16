using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleRenderer : MonoBehaviour
{
    public GameObject pauseBox;
    void Start()
    {
        pauseBox.SetActive(false);
        
    }
    public void ToggleVisibility()
    {
        Renderer rend = gameObject.GetComponent<Renderer>();

        if (rend.enabled)
        {
            rend.enabled = false;
            pauseBox.SetActive(false);
        }
        else
        {
            rend.enabled = true;
            pauseBox.SetActive(true);
        }
    }

}
