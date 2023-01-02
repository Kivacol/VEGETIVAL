using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class timeout : MonoBehaviour
{

    public GameObject continueButton;
    //public GameObject sittingButton;
    public GameObject quitButton;
    public GameObject back;

    public GameObject backButton;

    public GameObject gameOver;
    public GameObject win;

    //public GameObject test;

    // Start is called before the first frame update
    void Start()
    {
        continueButton.gameObject.SetActive(false);
        //sittingButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        back.gameObject.SetActive(false);

        backButton.gameObject.SetActive(false);

        //test.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            continueButton.gameObject.SetActive(true);
            //sittingButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
            back.gameObject.SetActive(true);
            //test.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Continue()
    {
        continueButton.gameObject.SetActive(false);
        //sittingButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        back.gameObject.SetActive(false);
        Debug.Log("繼續");
        Time.timeScale = 1;
    }

    public void Sitting()
    {

    }

    public void Quit()
    {
        Time.timeScale = 1;
        back.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
        

    }

    public void Back()
    {
        //Time.timeScale = 0;
        back.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
    }

    public void Win()
    {
        //Time.timeScale = 0;
        back.gameObject.SetActive(true);
        win.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
    }

    //public void Die()
    //{
    //    backButton.gameObject.SetActive(true);
    //    back.gameObject.SetActive(true);
    //}
}
