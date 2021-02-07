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
    float raycastDistance = 1f;


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

    private void FixedUpdate()
    {
            //10000000
       
            // Bit shift the index of the layer (8) groud to get a bit mask
            int layerMask = 1 << 8;

            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(groundCheck.position, groundCheck.TransformDirection(Vector3.down), out hit, raycastDistance, layerMask))
            {
                //Debug.DrawRay(groundCheck.position, groundCheck.TransformDirection(Vector3.down) * raycastDistance, Color.yellow);
                isGrounded = true;
            }
            else
            {
                //Debug.DrawRay(groundCheck.position, groundCheck.TransformDirection(Vector3.down) * raycastDistance, Color.white);
                isGrounded = false;
            }
       
    }

    // Update is called once per frame
    void Update()
    {
        
        //katsotaan koskeeko maata
       

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
   
}
