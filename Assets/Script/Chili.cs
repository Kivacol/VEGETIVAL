using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chili : MonoBehaviour
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
                uICtrl.SendMessage("ChiliAdd");
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
            && other.gameObject.name== "Original" || other.gameObject.name == "Original (1)")
        {
            canPull = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") 
            && other.gameObject.name == "Original" || other.gameObject.name == "Original (1)")
        {
            canPull = false;
        }
    }
}
