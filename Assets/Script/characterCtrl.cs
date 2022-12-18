using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterCtrl : MonoBehaviour
{
    public GameObject avater1, avater2, avater3, avater4, avater5;
    public int whichAvaterIsOn = 1;
    public GameObject currAvater;

    public static float speed =15f;
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
                avater1.transform.position = currAvater.transform.position;

                currAvater = avater1;
                avater1.gameObject.SetActive(true);
                avater2.gameObject.SetActive(false);
                avater3.gameObject.SetActive(false);
                avater4.gameObject.SetActive(false);
                avater5.gameObject.SetActive(false);
                //avater6.gameObject.SetActive(false);

                break;

            case 2:

                whichAvaterIsOn = 2;
                avater2.transform.position = currAvater.transform.position;

                currAvater = avater2;
                avater1.gameObject.SetActive(false);
                avater2.gameObject.SetActive(true);
                avater3.gameObject.SetActive(false);
                avater4.gameObject.SetActive(false);
                avater5.gameObject.SetActive(false);
                //avater6.gameObject.SetActive(false);

                break;

            case 3:

                whichAvaterIsOn = 3;
                avater3.transform.position = currAvater.transform.position;

                currAvater = avater3;
                avater1.gameObject.SetActive(false);
                avater2.gameObject.SetActive(false);
                avater3.gameObject.SetActive(true);
                avater4.gameObject.SetActive(false);
                avater5.gameObject.SetActive(false);
                //avater6.gameObject.SetActive(false);

                break;


            case 4:

                whichAvaterIsOn = 4;
                avater4.transform.position = currAvater.transform.position;

                currAvater = avater4;
                avater1.gameObject.SetActive(false);
                avater2.gameObject.SetActive(false);
                avater3.gameObject.SetActive(false);
                avater4.gameObject.SetActive(true);
                avater5.gameObject.SetActive(false);
                //avater6.gameObject.SetActive(false);

                break;


            case 5:

                whichAvaterIsOn = 5;
                avater5.transform.position = currAvater.transform.position;

                currAvater = avater5;
                avater1.gameObject.SetActive(false);
                avater2.gameObject.SetActive(false);
                avater3.gameObject.SetActive(false);
                avater4.gameObject.SetActive(false);
                avater5.gameObject.SetActive(true);
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
}
