using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class SlimeState
{
    public enum SLIME_STATE
    {
        IDLE, PATROL, COMBAT
    }

    public enum SLIME_EVENT
    {
        ENTER, UPDATE, EXIT
    }

    public SLIME_STATE slimeStateName;
    protected SLIME_EVENT stage;
    protected GameObject npc;
    protected GameObject wanderZone;
    protected Animator anim;
    protected Transform player;

    protected SlimeState nextState;
    protected NavMeshAgent agent;
    

    //Change these variables below to changable in inspector later
    float visDist = 10.0f;
    float visAngle = 10.0f;
    float attackDist = 7.0f;

    //This is the base class constructor, when we make a new state class (IDLE, ATTACK etc) we pass these into the constructor to ensure that the new state carries over the same monster and monsters target. basically provides continuity
    public SlimeState(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
    {

        npc = _npc;
        agent = _agent;
        anim = _anim;
        player = _player;

    }

    //Below are methods that we will implement in each states class. What to do when it is in Enter/update/Exit state. I know the Enter() looks silly since you expect enter, but you actually implement Enter() then change to EVENT.UPDATE at the end since we dont want to repeat Enter() since its only done once obviously

    public virtual void EnterStage() {stage = SLIME_EVENT.UPDATE;}
    public virtual void UpdateStage() {stage = SLIME_EVENT.UPDATE;}
    public virtual void ExitStage() {stage = SLIME_EVENT.EXIT;}


    //Below is a very important method. Its public. It is what will be called outside the slime to change/progress the state thru the stages ( Process-->  Enter ---process--> Update ---process--> Exit)
    //Notice the method returns a SlimeState. All states for the slime will Inherit from SlimeState so they are a SlimeState.  This script returns a METHOD 
    //Add more to this later, its important
    public SlimeState Process()
    {
        if (stage == SLIME_EVENT.ENTER) EnterStage();
        if (stage == SLIME_EVENT.UPDATE) UpdateStage();
        if (stage == SLIME_EVENT.EXIT)
        {
            ExitStage();
            return nextState;
        }
        return this;
        
    }


    








}
