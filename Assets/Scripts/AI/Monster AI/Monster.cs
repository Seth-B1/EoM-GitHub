using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public MonsterStats stats;
    public GameObject target;
    public Rigidbody rb;
    public MonsterData monsterData;
    public Monster _npc;
    public Animator _anim;
    public NavMeshAgent _agent;
    public StateMachine _stateMachine;

    // For Transition Conditions
    public bool moving;




    void Start()
    {
        
    }

    public void HandleDetection()
    {
        //Debug.Log("Creating Detection");
        Collider[] colliders = Physics.OverlapSphere(transform.position, monsterData.detectionRadius);

        for (int i = 0; i < colliders.Length; i++)
        {
            Debug.Log("Checking for collision...");
            PlayerStatistics player = colliders[i].transform.GetComponent<PlayerStatistics>();

            if (player != null)
            {
                //If player is found 
                Vector3 targetDirection = player.transform.position - transform.position;
                float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

                if (viewableAngle >= monsterData.minimumDetectionRange && viewableAngle <= monsterData.maximumDetectionRange)
                {
                    target = player.gameObject;
                }
                
            }
        
        }
    }


}
