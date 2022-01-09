using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorObjectController : MonoBehaviour
{
    public int numberEnemyHolder = 5;
    private int _curNumberEnemyHolder;
    public float timeBetweenGenerate = 5f;
    public float forceMoveGenerate = 100f;
    public GameObject objectGenerate;
    private void Start()
    {
        _curNumberEnemyHolder = 0;
        InvokeRepeating("generate", 0f, timeBetweenGenerate);
    }
    private void generate()
    {
        if (_curNumberEnemyHolder < numberEnemyHolder)
        {
            GameObject newObject = Instantiate(objectGenerate, transform.position, Quaternion.identity);
            GenerateeController generateeController = newObject.GetComponent<GenerateeController>();
            if (generateeController != null)
            {
                generateeController.setGenerator(this);
                Rigidbody2D newObjectRB = newObject.GetComponent<Rigidbody2D>();
                if (newObjectRB != null)
                {
                    Vector2 vector2 = new Vector2(Random.value, Random.value);
                    vector2 = vector2.normalized * forceMoveGenerate * Time.deltaTime;
                    newObjectRB.AddForce(vector2);
                    _curNumberEnemyHolder++;
                }
            }
        }
    }
    public void lostHolder()
    {
        _curNumberEnemyHolder--;
    }
}
