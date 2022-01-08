using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public Canvas canvas;
    public static CanvasController instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    public float getScaleFactor()
    {
        return canvas.scaleFactor;
    }
}
