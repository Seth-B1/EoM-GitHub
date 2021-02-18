using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ItemOnFloor : MonoBehaviour
{
    public Camera playerView;
    public bool playerInRange;
    public float floatSpeed = 1.0f;
    public float detectPlayerRange = 1.0f;
    public Animator animator;


    void Start()
    {
        playerInRange = false;
 
    }
        void OnDrawGizmosSelected()
        {
        Gizmos.DrawSphere(transform.position, detectPlayerRange);
        }

    void Update()
    {

        transform.rotation = Quaternion.Euler(playerView.transform.rotation.eulerAngles.x, 0f , 0f);

        Collider[] thingsInRange = (Physics.OverlapSphere(transform.position, detectPlayerRange));
        foreach (Collider thing in thingsInRange)
        {
            if (thing.tag == "Player")
            {
                playerInRange = true;
            }
        }
        if (playerInRange)
        {
            animator.SetBool("floatToPlayer", true);

            float step = floatSpeed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, FindObjectOfType<S_Player>().GetComponent<Transform>().position, step);
        }


        
    }

    }

