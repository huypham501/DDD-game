using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform destination; 

    public Transform GetDestination()
    {
        return destination;
    }
}
