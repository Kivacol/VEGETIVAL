using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterCtrl : MonoBehaviour
{
    public GameObject avater1, avater2, avater3, avater4, avater5;
    public int whichAvaterIsOn = 1;
    public GameObject currAvater;

    public static float speed =15f;

    public Vector3 currPos;
    // Start is called before the first frame update
    void Start()
    {
        currAvater = avater1;
        //avater1.gameObject.SetActive(true);
        //avater2.gameObject.SetActive(false);
        //avater3.gameObject.SetActive(false);
        //avater4.gameObject.SetActive(false);
        //avater5.gameObject.SetActive(false);
    }


    public void SwitchAvater()
    {
        switch (whichAvaterIsOn)
        {
            case 1:

                whichAvaterIsOn = 1;
                
                avater1.gameObject.SetActive(true);
                //Debug.Log("A1" + avater1.transform.position);
                //Debug.Log("CURR" + currAvater.transform.position);
                currPos = currAvater.transform.position;
                //avater1.transform.position = currAvater.transform.position + new Vector3(0, 2, 0);
                //Debug.Log(currAvater.transform.position);
                //Debug.Log("A1-2" + avater1.transform.position);
                avater2.gameObject.SetActive(false);
                avater3.gameObject.SetActive(false);
                avater4.gameObject.SetActive(false);
                avater5.gameObject.SetActive(false);
                currAvater = avater1;
                //avater6.gameObject.SetActive(false);
                //Debug.Log("A1-3" + avater1.transform.position);
                Invoke("resetCurr", 0.01f);
                Invoke("resetCurr", 0.02f);
                Invoke("resetCurr", 0.03f);
                Invoke("resetCurr", 0.04f);
                break;

            case 2:

                whichAvaterIsOn = 2;
            
                avater2.gameObject.SetActive(true);
                
                avater2.transform.position = currAvater.transform.position;
                avater3.gameObject.SetActive(false);
                avater4.gameObject.SetActive(false);
                avater5.gameObject.SetActive(false);
                avater1.gameObject.SetActive(false);
                currAvater = avater2;
                //avater6.gameObject.SetActive(false);

                break;

            case 3:

                whichAvaterIsOn = 3;
                
                avater3.gameObject.SetActive(true);
                
                avater3.transform.position = currAvater.transform.position;
                avater4.gameObject.SetActive(false);
                avater5.gameObject.SetActive(false);
                avater1.gameObject.SetActive(false);
                avater2.gameObject.SetActive(false);
                currAvater = avater3;
                //avater6.gameObject.SetActive(false);

                break;


            case 4:

                whichAvaterIsOn = 4;
                
                avater4.gameObject.SetActive(true);
                
                avater4.transform.position = currAvater.transform.position;
                avater5.gameObject.SetActive(false);
                avater1.gameObject.SetActive(false);
                avater2.gameObject.SetActive(false);
                avater3.gameObject.SetActive(false);
                currAvater = avater4;
                //avater6.gameObject.SetActive(false);

                break;


            case 5:

                whichAvaterIsOn = 5;
                
                
                avater5.gameObject.SetActive(true);
                avater5.transform.position = currAvater.transform.position;
                avater1.gameObject.SetActive(false);
                avater2.gameObject.SetActive(false);
                avater3.gameObject.SetActive(false);
                avater4.gameObject.SetActive(false);
                currAvater = avater5;
                //avater6.gameObject.SetActive(false);

                break;

            //case 6:

            //    whichAvaterIsOn = 6;
            //    avater6.transform.position = currAvater.transform.position;

            //    currAvater = avater5;
            //    avater1.gameObject.SetActive(false);
            //    avater2.gameObject.SetActive(false);
            //    avater3.gameObject.SetActive(false);
            //    avater4.gameObject.SetActive(false);
            //    avater5.gameObject.SetActive(false);
            //    //avater6.gameObject.SetActive(true);


                //break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            whichAvaterIsOn += 1;
            SwitchAvater();
        }
    }

    void resetCurr()
    {
        avater1.transform.position = currPos;
        avater1.gameObject.SendMessage("setSpeed");
        //Debug.Log("A1-4" + avater1.transform.position);
        //if (avater1.transform.position == currPos) {
        //    CancelInvoke("resetCurr");
        //}
    }
}
