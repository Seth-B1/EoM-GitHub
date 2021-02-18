using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public Transform groundCheckTransform;
    private bool jumpKeyWasPressed;
    private float horizontalInput;

    private Rigidbody rigidBodyComponent;

    

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        
         
        }
        private void FixedUpdate()
        {
           if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f).Length == 1)
           {
               return;
           }   


         
        
        if (jumpKeyWasPressed )
        {
            rigidBodyComponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange );
            jumpKeyWasPressed = false;

        }
        

        
    }

 
}

