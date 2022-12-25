using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    public GameObject enemy;

    public int enemyCount;
    public int enemyNumber;
    public int enemyTime;

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = 0;
        enemyNumber = 1;
        enemyTime = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount==0 && enemyTime>0)
        {
            for (int i = 0; i < enemyNumber; i++)
            {
                
                GameObject temp = Instantiate(enemy, new Vector3(Random.Range(30f, 120f), 5f, Random.Range(120f, 30f)), Quaternion.identity);
                temp.SetActive(true);
                enemyCount++;
            }
                enemyTime--;
            
            if (enemyTime==2)
            {
                enemyNumber = 3;
            }
            else if (enemyTime==1)
            {
                enemyNumber = 5;
            }

        }
    }

    public void enemyDie()
    {
        enemyCount--;
    }
}
