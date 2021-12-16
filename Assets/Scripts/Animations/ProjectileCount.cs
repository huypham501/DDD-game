using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileCount : MonoBehaviour
{
    public static int Projectile = 0;
    //Text Projectile;
    // Start is called before the first frame update
    void Start()
    {
        //Projectile = GetComponent<Text>();
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 30;
        style.normal.textColor = Color.black;
        GUI.Label(new Rect(170, 90, 100, 20), "x" + Projectile, style);
    }
}
