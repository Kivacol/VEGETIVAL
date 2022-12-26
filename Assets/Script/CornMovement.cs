using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    private Animator animator;
    private CharacterController character;
    private float ySpeed;
    private float originalStepOffest;

    public CornCtrl Corn;

    public Camera followCamera;

    public int coldDownCount;

    AudioSource audioSource;
    public AudioClip hurt;
    public AudioClip shoot;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        character = GetComponent<CharacterController>();
        originalStepOffest = character.stepOffset;
        audioSource = GetComponent<AudioSource>();
    }


    IEnumerator shootTimer()
    {
        yield return new WaitForSeconds(1f);
        speed = 7f;
        rotationSpeed = 10f;
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

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            AudioCtrl.StopFootstepAudio();
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
            //StartCoroutine(TimerRoutine());
            audioSource.PlayOneShot(shoot);
            animator.SetTrigger("T_isShoot");
            speed = 0f;
            rotationSpeed = 0f;
            CornCtrl cornbull = Instantiate(Corn, transform.position + new Vector3(0, 2, 0), transform.rotation);
            cornbull.dic = transform.forward;
            StartCoroutine("shootTimer");

        }

    }

    //private IEnumerator TimerRoutine()
    //{
    //    yield return new WaitForSeconds(5);
    //    animator.SetTrigger("T_isShoot");
    //    speed = 0f;
    //    rotationSpeed = 0f;
    //    CornCtrl cornbull = Instantiate(Corn, transform.position + new Vector3(0, 2, 0), transform.rotation);
    //    cornbull.dic = transform.forward;
    //    StartCoroutine("shootTimer");//code can be executed anywhere here before this next statement 
        

    //    //code pauses for 5 seconds
    //                                        //code resumes after the 5 seconds and exits if there is nothing else to run

    //}

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
}
