using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
public class Slime : Monster
{
    public Vector3 _startPos;
    public virtual void Awake()
    {
        _startPos = transform.position;

        rb = this.GetComponent<Rigidbody>();
       
        _npc = this;
        _anim = GetComponent<Animator>();
        _agent = this.GetComponent<NavMeshAgent>();
        _stateMachine = new StateMachine();



        stats = new MonsterStats(monsterData);


        //Create Possible States for this Monster (Slime)
        var idle = new Idle(_npc, _anim, _agent);
        var patrol = new Patrol(_npc, _anim, _agent, _startPos);

        


        //Defining the possible Transitions and their conditions
        AddTransition(idle, patrol, MonsterIsPatrolling());
        AddTransition(patrol, idle, MonsterIsAtPatrolDestination());



        //Conditions are defined here
        Func<bool> MonsterIsPatrolling() => () => moving;
        Func<bool> MonsterIsAtPatrolDestination() => () => moving == false;
        


        //Default State
        _stateMachine.SetState(idle);
    }

    void Update()
    {
        _stateMachine.Tick();
    }







    //Shortcut methods
    void AddTransition(IState from, IState to, Func<bool> condition)
    {
        _stateMachine.AddTransition(from, to, condition);
    }

}
