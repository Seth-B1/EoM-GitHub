using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Animations : MonoBehaviour
{
    Animator animator;
    public Joystick joystick_animation;
    //public GameObject inventoryScreen;
    void Start()
    {
        animator = GetComponent<Animator>();
        
        
    }


    void Update()
    {
        if (joystick_animation.Horizontal != 0 && joystick_animation.Vertical != 0 )
        {
            animator.SetBool("isMoving", true);
        }

        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}
