using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Flame : MonoBehaviour
{
    public VisualEffect flame;
    // Start is called before the first frame update
    void Start()
    {
        flame.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            flame.Play();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            flame.Stop();
        }
    }
}
