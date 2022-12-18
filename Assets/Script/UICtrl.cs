using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICtrl : MonoBehaviour
{
    public int LifePoint = 3;
    public GameObject Life1;
    public GameObject Life2;
    public GameObject Life3;
    public GameObject BadLife1;
    public GameObject BadLife2;
    public GameObject BadLife3;

    public GameObject[] myPlayer;

    public GameObject[] chili = new GameObject[5];
    public GameObject[] onion = new GameObject[5];
    public GameObject[] brocoil = new GameObject[5];
    public GameObject[] corn = new GameObject[5];

    public GameObject chiliIcon;
    public GameObject onionIcon;
    public GameObject cornIcon;
    public GameObject brocoilIcon;
    public GameObject ogIcon;

    public int chiliCount = 0;
    public int onionCount = 0;
    public int brocoilCount = 0;
    public int cornCount = 0;


    public characterCtrl characterCtrl;

    public GameObject Button;

    //public float speed;

    // Start is called before the first frame update
    void Start()
    {
        BadLife1.gameObject.SetActive(false);
        BadLife2.gameObject.SetActive(false);
        BadLife3.gameObject.SetActive(false);

        //DontDestroyOnLoad(gameObject);

        Cursor.visible = true;
        Screen.lockCursor = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //生命值

    public void Damage()
    {
        
        LifePoint = LifePoint - 1;



        //根據愛心數量，顯示愛心圖案

        if (LifePoint == 2) //如果還有兩顆愛心

        {

            //讓第一顆愛心隱藏

            Life3.SetActive(false);
            BadLife3.gameObject.SetActive(true);
            myPlayer = GameObject.FindGameObjectsWithTag("Player");
            myPlayer[0].SendMessage("HurtAnime");

        }

        else if (LifePoint == 1) //如果還有一顆愛心

        {

            //讓第二顆愛心隱藏

            Life2.SetActive(false);
            BadLife2.gameObject.SetActive(true);
            myPlayer = GameObject.FindGameObjectsWithTag("Player");
            myPlayer[0].SendMessage("HurtAnime");

        }

        else if (LifePoint == 0) //如果沒有愛心

        {

            //讓第三顆愛心隱藏

            Life1.SetActive(false);
            BadLife1.gameObject.SetActive(true);

        }
        if (LifePoint == 0)
        {
            myPlayer = GameObject.FindGameObjectsWithTag("Player");
            myPlayer[0].SendMessage("DeadAnime");
            myPlayer[0].SendMessage("StopPlayer");
            Invoke("Dead", 1);
            Button.SendMessage("Back");
        }
    }
    private void Dead()
    {
        Debug.Log("死亡");
        //Application.LoadLevel(3);
    }
    //辣椒++
    public void ChiliAdd()
    {
        chiliCount ++;
        if (chiliCount==1)
        {
            chili[0].gameObject.SetActive(false);
            chili[1].gameObject.SetActive(true);
        }
        else if(chiliCount == 2)
        {
            chili[1].gameObject.SetActive(false);
            chili[2].gameObject.SetActive(true);
        }
        else if (chiliCount == 3)
        {
            chili[2].gameObject.SetActive(false);
            chili[3].gameObject.SetActive(true);
        }
        else if (chiliCount >= 4 )
        {
            ogIcon.gameObject.SetActive(false);
            chili[3].gameObject.SetActive(false);
            chili[4].gameObject.SetActive(true);
            chiliIcon.gameObject.SetActive(true);
            characterCtrl.whichAvaterIsOn = 2;
            characterCtrl.SwitchAvater();
            Invoke("ChiliResetOG", 30);
        }
    }

    public void OnionAdd()
    {
        onionCount++;
        if (onionCount == 1)
        {
            onion[0].gameObject.SetActive(false);
            onion[1].gameObject.SetActive(true);
        }
        else if (onionCount == 2)
        {
            onion[1].gameObject.SetActive(false);
            onion[2].gameObject.SetActive(true);
        }
        else if (onionCount == 3)
        {
            onion[2].gameObject.SetActive(false);
            onion[3].gameObject.SetActive(true);
        }
        else if (onionCount >= 4 )
        {
            ogIcon.gameObject.SetActive(false);
            onion[3].gameObject.SetActive(false);
            onion[4].gameObject.SetActive(true);
            onionIcon.gameObject.SetActive(true);
            characterCtrl.whichAvaterIsOn = 3;
            characterCtrl.SwitchAvater();
            Invoke("OnionResetOG", 30);
        }
    }

    public void CornAdd()
    {
        cornCount++;
        if (cornCount == 1)
        {
            corn[0].gameObject.SetActive(false);
            corn[1].gameObject.SetActive(true);
        }
        else if (cornCount == 2)
        {
            corn[1].gameObject.SetActive(false);
            corn[2].gameObject.SetActive(true);
        }
        else if (cornCount == 3)
        {
            corn[2].gameObject.SetActive(false);
            corn[3].gameObject.SetActive(true);
        }
        else if (cornCount >= 4 )
        {
            ogIcon.gameObject.SetActive(false);
            corn[3].gameObject.SetActive(false);
            corn[4].gameObject.SetActive(true);
            cornIcon.gameObject.SetActive(true);
            characterCtrl.whichAvaterIsOn = 5;
            characterCtrl.SwitchAvater();
            Invoke("CornResetOG", 30);
        }
    }

    public void BrocoilAdd()
    {
        brocoilCount++;
        if (brocoilCount == 1)
        {
            brocoil[0].gameObject.SetActive(false);
            brocoil[1].gameObject.SetActive(true);
        }
        else if (brocoilCount == 2)
        {
            brocoil[1].gameObject.SetActive(false);
            brocoil[2].gameObject.SetActive(true);
        }
        else if (brocoilCount == 3)
        {
            brocoil[2].gameObject.SetActive(false);
            brocoil[3].gameObject.SetActive(true);
        }
        else if (brocoilCount >= 4 )
        {
            ogIcon.gameObject.SetActive(false);
            brocoil[3].gameObject.SetActive(false);
            brocoil[4].gameObject.SetActive(true);
            brocoilIcon.gameObject.SetActive(true);
            characterCtrl.whichAvaterIsOn = 4;
            characterCtrl.SwitchAvater();
            Invoke("BrocoilResetOG", 30);
        }
    }

    public void ChiliResetOG()
    {
        characterCtrl.whichAvaterIsOn = 1;
        characterCtrl.SwitchAvater();
        //speed = characterCtrl.speed;
        //重置蔬菜值
        chili[0].gameObject.SetActive(true);
        chili[1].gameObject.SetActive(false);
        chili[2].gameObject.SetActive(false);
        chili[3].gameObject.SetActive(false);
        chili[4].gameObject.SetActive(false);
        chiliIcon.gameObject.SetActive(false);
        ogIcon.gameObject.SetActive(true);
        chiliCount = 0;
    }

    public void OnionResetOG()
    {
        characterCtrl.whichAvaterIsOn = 1;
        characterCtrl.SwitchAvater();

        onion[0].gameObject.SetActive(true);
        onion[1].gameObject.SetActive(false);
        onion[2].gameObject.SetActive(false);
        onion[3].gameObject.SetActive(false);
        onion[4].gameObject.SetActive(false);
        onionIcon.gameObject.SetActive(false);
        ogIcon.gameObject.SetActive(true);
        onionCount = 0;
    }

    public void CornResetOG()
    {
        characterCtrl.whichAvaterIsOn = 1;
        characterCtrl.SwitchAvater();

        corn[0].gameObject.SetActive(true);
        corn[1].gameObject.SetActive(false);
        corn[2].gameObject.SetActive(false);
        corn[3].gameObject.SetActive(false);
        corn[4].gameObject.SetActive(false);
        cornIcon.gameObject.SetActive(false);
        ogIcon.gameObject.SetActive(true);
        cornCount = 0;
    }

    public void BrocoilResetOG()
    {
        characterCtrl.whichAvaterIsOn = 1;
        characterCtrl.SwitchAvater();

        brocoil[0].gameObject.SetActive(true);
        brocoil[1].gameObject.SetActive(false);
        brocoil[2].gameObject.SetActive(false);
        brocoil[3].gameObject.SetActive(false);
        brocoil[4].gameObject.SetActive(false);
        brocoilIcon.gameObject.SetActive(false);
        ogIcon.gameObject.SetActive(true);
        brocoilCount = 0;
    }



}