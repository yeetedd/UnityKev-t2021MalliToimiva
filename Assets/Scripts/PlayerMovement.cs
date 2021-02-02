using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public GameObject camera;

    public float speed = 8f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded = true;

    private Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //katsotaan koskeeko maata
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }
        
        //Lasketaan mihin suuntaan on mentava
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = camera.transform.right * x + camera.transform.forward * z;

        //kerrotaan etta on liikuttava
        controller.Move(move * speed * Time.deltaTime);

        //hypyn koodi
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            
        }
        velocity.y += gravity * Time.deltaTime;
        
        //putoaminen
        controller.Move(velocity * Time.deltaTime);
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
