﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrocoliMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    private Animator animator;
    private CharacterController character;
    private float ySpeed;
    private float originalStepOffest;

    public GameObject power;

    public Camera followCamera;

    AudioSource audioSource;
    public AudioClip hurt;
    public AudioClip waaaa;
    //衝刺
    //ThirdPersonCamera movement;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        character = GetComponent<CharacterController>();
        originalStepOffest = character.stepOffset;
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator powerTimer()
    {
        yield return new WaitForSeconds(5f);
        speed = 7f;
        power.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            AudioCtrl.PlayFootstepAudio();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            AudioCtrl.PlayFootstepAudio();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            AudioCtrl.PlayFootstepAudio();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            AudioCtrl.PlayFootstepAudio();
        }

        Movement();

        //float horizontaInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

        //Vector3 movementDirection = new Vector3(horizontaInput, 0, verticalInput);
        //float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        //movementDirection.Normalize();

        //ySpeed += Physics.gravity.y * Time.time;

        //Vector3 velocity = movementDirection * magnitude;
        //velocity.y = ySpeed;

        //characterController.Move(velocity * Time.deltaTime);

        //if (movementDirection != Vector3.zero)
        //{
        //    animator.SetBool("isRun", true);
        //    Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        //}
        //else
        //{
        //    animator.SetBool("isRun", false);
        //}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(waaaa);
            animator.SetTrigger("T_isAttack");
            //speed = 12f;
            //StartCoroutine(Dash());
            power.SetActive(true);
            StartCoroutine("powerTimer");

        }

    }

    void Movement()
    {
        float horizontaInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementInput = Quaternion.Euler(0, followCamera.transform.eulerAngles.y, 0) * new Vector3(horizontaInput, 0, verticalInput);
        Vector3 movementDirection = movementInput.normalized;
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;



        ySpeed += Physics.gravity.y * Time.time;

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;
        character.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("isRun", true);
            Quaternion desiredRotaion = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotaion, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isRun", false);
        }

        character.Move(movementDirection * speed * Time.deltaTime);
    }
    public void HurtAnime()
    {
        audioSource.PlayOneShot(hurt);
        animator.SetTrigger("T_isHurt");
    }

    public void DeadAnime()
    {
        animator.SetTrigger("T_isDead");
    }

    public void StopPlayer()
    {
        speed = 0f;
        rotationSpeed = 0f;
    }

    public void setSpeed()
    {
        speed = 7f;
        rotationSpeed = 10f;
    }

    //IEnumerable Dash()
    //{

    //}
}
