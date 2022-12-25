using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{

    private Animator animator;
    public GameObject p1, p2, p3, p4, p5;
    public GameObject c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12,c13,c14,c15;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void start()
    {
        animator.SetTrigger("T_isUp");

        Invoke("WaitStart", 1.10f);
        //animator.SetTrigger("T_isPlay");
        Invoke("Play", 3.6f);
    }

    public void QuitGame()
    {
        animator.SetTrigger("T_isUp");

        Invoke("WaitQuit", 1.0f);
        Invoke("Colse", 4);
        //Application.Quit();
    }

    public void Crdit()
    {
        animator.SetTrigger("T_isUp");
        

        Invoke("WaitCrdit", 1f);
        Invoke("QuitCrdit",3.20f);
    }

    public void CrditBack()
    {
        p5.gameObject.SetActive(false);
        animator.SetTrigger("T_isOut");
        //Invoke("")
        Invoke("TitleShow", 2f);
        //animator.SetTrigger("T_isDown");
    }

    void QuitCrdit()
    {
        p5.gameObject.SetActive(true);
    }

    void TitleShow()
    {

        p1.gameObject.SetActive(true);
        p2.gameObject.SetActive(true);
        p3.gameObject.SetActive(true);
        p4.gameObject.SetActive(true);

        
        c1.gameObject.SetActive(true);
        c2.gameObject.SetActive(true);
        c3.gameObject.SetActive(true);
        c4.gameObject.SetActive(true);
        c5.gameObject.SetActive(true);
        c6.gameObject.SetActive(true);
        c7.gameObject.SetActive(true);
        c8.gameObject.SetActive(true);
        c9.gameObject.SetActive(true);
        c10.gameObject.SetActive(true);
        c11.gameObject.SetActive(true);
        c12.gameObject.SetActive(true);
        animator.SetTrigger("T_isDown");

    }

    void OutGame()
    {
        Application.Quit();
    }

    void Play()
    {
        SceneManager.LoadScene(1);
    }

    void WaitStart()
    {
        p1.gameObject.SetActive(false);
        p2.gameObject.SetActive(false);
        p3.gameObject.SetActive(false);
        p4.gameObject.SetActive(false);
        c1.gameObject.SetActive(false);
        c2.gameObject.SetActive(false);
        c3.gameObject.SetActive(false);
        c4.gameObject.SetActive(false);
        c5.gameObject.SetActive(false);
        c6.gameObject.SetActive(false);
        c7.gameObject.SetActive(false);
        c8.gameObject.SetActive(false);
        c9.gameObject.SetActive(false);
        c10.gameObject.SetActive(false);
        c11.gameObject.SetActive(false);
        c12.gameObject.SetActive(false);
        animator.SetTrigger("T_isPlay");
    }

    void WaitCrdit()
    {
        p1.gameObject.SetActive(false);
        p2.gameObject.SetActive(false);
        p3.gameObject.SetActive(false);
        p4.gameObject.SetActive(false);
        c1.gameObject.SetActive(false);
        c2.gameObject.SetActive(false);
        c3.gameObject.SetActive(false);
        c4.gameObject.SetActive(false);
        c5.gameObject.SetActive(false);
        c6.gameObject.SetActive(false);
        c7.gameObject.SetActive(false);
        c8.gameObject.SetActive(false);
        c9.gameObject.SetActive(false);
        c10.gameObject.SetActive(false);
        c11.gameObject.SetActive(false);
        c12.gameObject.SetActive(false);
        animator.SetTrigger("T_isIn");
    }

    void WaitQuit()
    {
        p1.gameObject.SetActive(false);
        p2.gameObject.SetActive(false);
        p3.gameObject.SetActive(false);
        p4.gameObject.SetActive(false);
        c1.gameObject.SetActive(false);
        c2.gameObject.SetActive(false);
        c3.gameObject.SetActive(false);
        c4.gameObject.SetActive(false);
        c5.gameObject.SetActive(false);
        c6.gameObject.SetActive(false);
        c7.gameObject.SetActive(false);
        c8.gameObject.SetActive(false);
        c9.gameObject.SetActive(false);
        c10.gameObject.SetActive(false);
        c11.gameObject.SetActive(false);
        c12.gameObject.SetActive(false);
        animator.SetTrigger("T_isQuit");
    }

    void Colse()
    {
        animator.SetTrigger("T_isColse");
    }
}
