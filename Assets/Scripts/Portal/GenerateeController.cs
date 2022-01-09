using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateeController : MonoBehaviour
{
    private GeneratorObjectController generator;
    public void setGenerator(GeneratorObjectController otherGenerator)
    {
        generator = otherGenerator;
    }
    private void OnDestroy() {
        generator.lostHolder();
    }
}
