using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public CharacterController character;

    public float speed = 7f;

    public float rotaionSpeed = 10f;

    public Camera followCamera;

    
    void Start()
    {
        character = GetComponent<CharacterController>();
       
    }

    
    void Update()
    {
        Movement();
        
    }

    void Movement()
    {
        float horizontaInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementInput = Quaternion.Euler(0,followCamera.transform.eulerAngles.y,0) * new Vector3(horizontaInput, 0, verticalInput);
        Vector3 movementDirection = movementInput.normalized;

        if (movementDirection != Vector3.zero)
        {
            Quaternion desiredRotaion = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.Slerp(transform.rotation,desiredRotaion,rotaionSpeed * Time.deltaTime);
        }

        character.Move(movementDirection * speed * Time.deltaTime);
    }

   
}
