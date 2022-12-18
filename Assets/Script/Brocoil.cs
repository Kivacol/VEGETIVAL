using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brocoil : MonoBehaviour
{
    public bool canPull;
    

    AudioSource audioSource;
    public AudioClip pull;

    public GameObject uICtrl;
    // Start is called before the first frame update
    void Start()
    {
        canPull = false;

        audioSource = GetComponent<AudioSource>();

        Destroy(gameObject, 10);

        uICtrl = GameObject.Find("UICtrl");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canPull == true)
            {
                audioSource.PlayOneShot(pull);
                Invoke("getVe", 1);
                uICtrl.SendMessage("BrocoilAdd");
                }
        }
    }

    private void getVe()
    {

        Destroy(gameObject);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") 
            && other.gameObject.name== "Original" )
        {
            canPull = true;
            other.gameObject.SendMessage("IsBrocoli");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") 
            && other.gameObject.name == "Original" )
        {
            canPull = false;
        }
    }
}
