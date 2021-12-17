using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public int IndexScene;
    public string SceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;

    public void TriggerOnEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerStorage.initialValue = playerPosition;
            SceneManager.LoadScene(IndexScene);
            //SceneManager.LoadScene(SceneToLoad);
        }
    }
}
