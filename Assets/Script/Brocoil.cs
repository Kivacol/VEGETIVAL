using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brocoil : MonoBehaviour
{
    public bool canPull;
    

    AudioSource audioSource;
    public AudioClip pull;

    public GameObject uICtrl;

    private Animator animator;

    //public Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        //startPosition = gameObject.transform.position;

        canPull = false;

        audioSource = GetComponent<AudioSource>();

        Destroy(gameObject, 20);

        uICtrl = GameObject.Find("UICtrl");

        animator = GetComponent<Animator>();

        //GameObject.GetComponent<Transform>().position
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canPull == true)
            {
                audioSource.PlayOneShot(pull);
                //animator.SetTrigger("T_isPull");
                GetVegetable();
                Invoke("getVe", 1.6f);
                
                uICtrl.SendMessage("BrocoilAdd");
                canPull = false;
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

    public void GetVegetable()
    {
        //startPosition = new Vector3(transform.position.x,transform.position.y,transform.position.z);

        //new Vector3(transform.position.x, transform.position.y, transform.position.z) = Vector3(transform.position.x, transform.position.y, transform.position.z);
        //Vector3 newPosition = transform.position;
        animator.SetTrigger("T_isPull");
        //transform.position = newPosition;
    }
}
