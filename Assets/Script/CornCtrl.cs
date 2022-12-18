using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornCtrl : MonoBehaviour
{
    public Vector3 dic;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("shootTimer");
    }


    IEnumerator shootTimer()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += dic;
    }
}
