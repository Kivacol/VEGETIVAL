using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetNew : MonoBehaviour
{
    public GameObject[] Vegetable;
    //public Transform[] Points;
    //public GameObject Veget;
    public float Ins_Time = 10;

    public int VeagetableCount;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Ins_Objs", 0, 10);
        
    }

    void Ins_Objs() //生成物件函式。

    {
        for (int i = 0; i < VeagetableCount; i++)
            Instantiate(Vegetable[Random.Range(0,4)], new Vector3(Random.Range(60f, 150f),4.5f, Random.Range(160f, 60f)), Quaternion.identity);
        //int Random_Objects = Random.Range(0, Vegetable.Length);

        //int Random_Points = Random.Range(0, Points.Length);
        //Instantiate(Vegetable[Random_Objects], new Vector3(Random.Range(-55f, 0f), 95, Random.Range(100f, -60f)), Quaternion.identity);
        //Instantiate(Vegetable[Random_Objects], Points[Random_Points].transform.position, Points[Random_Points].transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
