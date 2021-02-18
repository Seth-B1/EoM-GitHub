using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
[Header("Gravity and Movement")]
    public Joystick joystick;
    public Vector3 velocity;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundCheckRadius = 0.5f;
    public LayerMask groundMask;
    public bool isGrounded;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        //Ground Check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);
        // will return true if sphere sees layermask, otherwise returns false

        if (isGrounded == true && velocity.y <  0)
        {
            velocity.y = -2f;
        }

 
    float x = joystick.Horizontal;
    float z = joystick.Vertical;
    //Debug.Log(x + "and " + z);
    Vector3 direction = new Vector3(x, 0f, z).normalized;

    if(direction.magnitude >= 0.1f )
    {
        
        
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        //above 'targetAngle' uses Mathf.Atan2 which finds the angle of 2 points and returns in radians, we can append Mathf.Rad2Deg to turn it into a usable float value
        //In other words, we get the angle we want to point the player at, and this gives us that Y value we want to rotate it to 
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
       //above 'angle' uses SmoothDampAngle which takes an objects angle (the player in this case), a target angle, a ref variable to store the current velocity (turnSmoothVelocity), and lastly the duration of the smoothening 
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        controller.Move(direction * speed * Time.deltaTime);
    }
    
    
    //Gravity
    velocity.y += gravity * Time.deltaTime;    
    controller.Move(velocity * Time.deltaTime);
        // It looks weird how there is 2 Time.deltaTime here. This is just how to simulate realistic gravity dont think too hard about it
        
    }

}

