using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Idle : IState
{
    private protected Monster _npc;
    private protected Animator _anim;
    private protected NavMeshAgent _agent;
    private float timePassed;
    
    //public float waitTime;

    public float RandomNumber(float min, float max)
    {
        return Random.Range(min, max);
    }
    
    public Idle(Monster npc, Animator anim, NavMeshAgent agent)
    {
        _npc = npc;
        _anim = anim;
        _agent = agent;

        


    }

    public void Tick()
    {
        _npc.HandleDetection();
        
        timePassed += Time.deltaTime;

        if (timePassed >= RandomNumber(1f, 5f))
        {
            timePassed = 0;
            _npc.moving = true;
        }
    }

    public void OnEnter()
    {
        Debug.Log(_npc + " Entered Idle State");

        _anim.SetBool("Idle", true);

    }

    public void OnExit()
    {
        Debug.Log("Exiting Idle");
        _anim.SetBool("Idle", false);

    }
}
