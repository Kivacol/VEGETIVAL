﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onion : MonoBehaviour
{
    public bool canPull;
    

    AudioSource audioSource;
    public AudioClip pull;

    public GameObject uICtrl;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        canPull = false;

        audioSource = GetComponent<AudioSource>();

        Destroy(gameObject, 20);

        uICtrl = GameObject.Find("UICtrl");

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canPull == true)
            {
                audioSource.PlayOneShot(pull);
                animator.SetTrigger("T_isPull");
                Invoke("getVe", 1.6f);
                uICtrl.SendMessage("OnionAdd");
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
            && other.gameObject.name== "Original"|| other.gameObject.name == "Original (1)")
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
