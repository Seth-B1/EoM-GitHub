using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : IState
{
    private protected Monster _npc;
    private protected Animator _anim;
    private protected NavMeshAgent _agent;
    private protected Vector3 _startPos;
    public Patrol(Monster npc, Animator anim, NavMeshAgent agent, Vector3 startPos)
    {
        _npc = npc;
        _anim = anim;
        _agent = agent;
        _startPos = startPos;
    }
    


    public void Tick()
    {
        _npc.HandleDetection();

        if (_agent.remainingDistance <= 1)
        {
            _anim.SetBool("Walk", false);
            _anim.SetBool("Idle", true);
            _npc.moving = false;
        }
    }

    public void OnEnter()
    {
        Debug.Log(_npc + " Has entered Patrol");
        _anim.SetBool("Walk", true);

        Vector3 newDestination = new Vector3(RandomNumber(_startPos.x - 10f, _startPos.x + 10f), _startPos.y, RandomNumber(_startPos.z - 10f, _startPos.z + 10f));
        _agent.SetDestination(newDestination);

    }

    public void OnExit()
    {
        Debug.Log(_npc + " Has exited Patrol");
    }



    public float RandomNumber(float min, float max)
    {
        return Random.Range(min, max);
    }

}
