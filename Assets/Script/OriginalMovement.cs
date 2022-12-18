using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginalMovement : MonoBehaviour
{
    //角色操作
    public float speed = 7;

    public float rotationSpeed = 10f;

    public Transform orientation;

    float horizontaInput;
    float verticalInput;

 

    public Animator animator;
    //private CharacterController characterController;
    public CharacterController character;
    private float ySpeed;
    private float originalStepOffest;

    AudioSource audioSource;
    public AudioClip wlak;

    public Camera followCamera;
//物件
    public GameObject Chil;
    public GameObject Onion;
    public GameObject Corn;
    public GameObject Brocoli;

    public int typeVegetable;

    //public static float OGspeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        speed = 7;
;       animator = GetComponent<Animator>();
        character = GetComponent<CharacterController>();
        originalStepOffest = character.stepOffset;

        audioSource = GetComponent<AudioSource>();

        typeVegetable = 0;
    }

    IEnumerator doTimer()
    {
        yield return new WaitForSeconds(1f);
        speed = 7f;
        rotationSpeed = 10f;
    }
    // Update is called once per frame
    void Update()
    {

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
            if (typeVegetable==1) {
                animator.SetTrigger("T_isDoBro");
                speed = 0f;
                rotationSpeed = 0f;

                StartCoroutine("doTimer");
            }
            else if (typeVegetable == 2)
            {

            }

            else if (typeVegetable == 3)
            {

            }

            else if (typeVegetable == 4)
            {

            }
           
            else 
            {
                animator.SetTrigger("T_isDo");
                speed = 0f;
                rotationSpeed = 0f;

                StartCoroutine("doTimer");
            }
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

    public static explicit operator OriginalMovement(GameObject v)
    {
        throw new NotImplementedException();
    }

    public void HurtAnime()
    {
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

    public void IsBrocoli()
    {
        typeVegetable = 1;
    }

    public void IsChil()
    {
        typeVegetable = 2;
    }

    public void IsCorn()
    {
        typeVegetable = 3;
    }

    public void IsOnion()
    {
        typeVegetable = 4;
    }

    public void setSpeed()
    {
        speed = 7f;
        rotationSpeed = 10f;
    }
}
