using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title1 : MonoBehaviour
{

    private Animator animator;
    public GameObject p1, p2, p3, p4, p5;
    public GameObject c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12,c13,c14,c15,c16;
    public AudioClip knook;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void start()
    {
        audioSource.PlayOneShot(knook);
        animator.SetTrigger("T_isUp");

        Invoke("WaitStart", 1.10f);
        //animator.SetTrigger("T_isPlay");
        //Invoke("Play", 3.6f);
    }

    public void QuitGame()
    {
        audioSource.PlayOneShot(knook);
        animator.SetTrigger("T_isUp");

        Invoke("WaitQuit", 1.0f);
        Invoke("Colse", 4);
        //Application.Quit();
    }

    public void Crdit()
    {
        audioSource.PlayOneShot(knook);
        animator.SetTrigger("T_isUp");
        

        Invoke("WaitCrdit", 1f);
        Invoke("QuitCrdit",3.20f);
    }

    public void CrditBack()
    {

        audioSource.PlayOneShot(knook);
        animator.SetTrigger("T_isCreBack");
        //animator.SetTrigger("T_isOut");
        Invoke("CreBack", 1.2f);
        
        
        Invoke("TitleShow", 3f);
        //animator.SetTrigger("T_isDown");
    }

    void QuitCrdit()
    {
        
        animator.SetTrigger("T_isCre");
        Invoke("show", 0.3f);

    }

    void show()
    {
        c16.gameObject.SetActive(true);
        c13.gameObject.SetActive(true);
        c14.gameObject.SetActive(true);
        c15.gameObject.SetActive(true);
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
        //animator.SetTrigger("T_isPlay");
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
        //animator.SetTrigger("T_isIn");
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
        //animator.SetTrigger("T_isQuit");
    }

    void Colse()
    {
        animator.SetTrigger("T_isColse");
    }

    void CreBack()
    {
        c16.gameObject.SetActive(false);
        c13.gameObject.SetActive(false);
        c14.gameObject.SetActive(false);
        c15.gameObject.SetActive(false);
        p5.gameObject.SetActive(false);
        //animator.SetTrigger("T_isOut");
    }

}
