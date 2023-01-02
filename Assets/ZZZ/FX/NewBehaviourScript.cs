using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class NewBehaviourScript : MonoBehaviour
{
    public VisualEffect flame;

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
