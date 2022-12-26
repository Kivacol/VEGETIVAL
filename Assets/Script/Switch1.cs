using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch1 : MonoBehaviour
{
    public int storyCount = 0;

    public Animator storyMan;

    public GameObject p0,p1,p2,p3,p4,p5,p6,p7,p8;

    public AudioClip paper;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        storyMan = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

       
    }

    public void right()
    {
        storyCount++;

        

        if (storyCount == 1)
        {
            storyMan.SetTrigger("T_1_0");
            audioSource.PlayOneShot(paper);
            //yield return new WaitForSeconds(1);
            Invoke("Pic1", 1);
        }

        if (storyCount == 2)
        {
            storyMan.SetTrigger("T_1");
            audioSource.PlayOneShot(paper);
            Invoke("Pic2", 1);

        }

        if (storyCount == 3)
        {
            storyMan.SetTrigger("T_2");
            audioSource.PlayOneShot(paper);
            Invoke("Pic3", 1);
        }

        if (storyCount == 4)
        {
            storyMan.SetTrigger("T_3");
            audioSource.PlayOneShot(paper);
            Invoke("Pic4", 1);
        }

        if (storyCount == 5)
        {
            storyMan.SetTrigger("T_4");
            audioSource.PlayOneShot(paper);
            Invoke("Pic5", 1);
        }

        if (storyCount == 6)
        {
            storyMan.SetTrigger("T_5");
            audioSource.PlayOneShot(paper);
            Invoke("Pic6", 1);
        }

        if (storyCount == 7)
        {
            storyMan.SetTrigger("T_6");
            audioSource.PlayOneShot(paper);
            Invoke("Pic7", 1);
        }

        if (storyCount == 8)
        {
            storyMan.SetTrigger("T_7");
            audioSource.PlayOneShot(paper);
            Invoke("Pic8", 2);
        }

        //if (storyCount == 9)
        //{
        //    storyMan.SetTrigger("T_8");
        //    audioSource.PlayOneShot(paper);
        //    Invoke("Pic9", 1);
        //}

        //if (storyCount == 10)
        //{
        //    storyMan.SetTrigger("T_9");
        //    audioSource.PlayOneShot(paper);
        //    Invoke("Pic10", 1);
        //}

        //if (storyCount ==11)
        //{
        //    storyMan.SetTrigger("T_10");
        //    audioSource.PlayOneShot(paper);
        //    Invoke("Pic11", 1);
        //}

        //if (storyCount == 12)
        //{
        //    storyMan.SetTrigger("T_11");
        //    //Invoke("Pic12", 2);
        //}


    }

    void Pic1()
    {
        p1.gameObject.SetActive(false);
    }

    void Pic2()
    {
        p2.gameObject.SetActive(false);
    }

    void Pic3()
    {
        p3.gameObject.SetActive(false);
    }

    void Pic4()
    {
        p4.gameObject.SetActive(false);
    }

    void Pic5()
    {
        p5.gameObject.SetActive(false);
    }

    void Pic6()
    {
        p6.gameObject.SetActive(false);
    }

    void Pic7()
    {
        p7.gameObject.SetActive(false);
    }

    void Pic8()
    {
        SceneManager.LoadScene(3);
    }

    //void Pic9()
    //{
        
    //}

    //void Pic10()
    //{
    //    p10.gameObject.SetActive(false);
    //}

    //void Pic11()
    //{
    //    p11.gameObject.SetActive(false);
    //}

    //void Pic12()
    //{
    //    SceneManager.LoadScene(2);
    //}



    //public void lift()
    //{

    //}

    public void skip()
    {
        Invoke("chage", 2);
        storyMan.SetTrigger("T_8");
    }

    void chage()
    {
        SceneManager.LoadScene(2);
    }
}
