using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EuipmentSystem : MonoBehaviour
{
    public GameObject testGameObject;
    public List<Sprite> transforms;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(testGameObject.name + " = " + transforms[0].name);
        SpriteRenderer spriteRendererTemp = testGameObject.transform.GetComponent<SpriteRenderer>();
        spriteRendererTemp.sprite = transforms[0];
        Debug.Log(spriteRendererTemp.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
