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
        SpriteRenderer spriteRendererTemp = testGameObject.transform.GetComponent<SpriteRenderer>();
        spriteRendererTemp.sprite = transforms[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
