using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Slime_Combat : SlimeState
{
    Vector3 playerDirection;
    Quaternion npcFacePlayerRotation;
    
    public Slime_Combat(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
                        : base(_npc, _agent, _anim, _player)
    {
        playerDirection = player.position - npc.transform.position;
        playerDirection.y = 0;
        npcFacePlayerRotation = Quaternion.LookRotation(playerDirection);

        slimeStateName = SLIME_STATE.COMBAT;
    }

    public override void EnterStage()
     {
         //rotate slime to look at player and play alert notification above head
         anim.SetBool("inCombat", true);
         Debug.Log(npc.name + " is entering Combat State");
    
         npc.transform.rotation = npcFacePlayerRotation;
         stage = SLIME_EVENT.UPDATE;
    }

    public override void UpdateStage()
    {
        //Detects when to Attack 1
        if(Vector3.Distance(player.position, npc.transform.position) <= 2.0)
        {
            playerDirection = player.position - npc.transform.position;
            playerDirection.y = 0;
            PursuitPlayer(false);

            npc.transform.rotation = npcFacePlayerRotation;
            //StartCoroutine(Attacks("Attack1"));
        }
        
        else if(Vector3.Distance(player.position, npc.transform.position) >= 2.0)
        {
            PursuitPlayer(true);
        }
        
        Debug.Log("Slime is combating");
        stage = SLIME_EVENT.UPDATE;
    }

    public override void ExitStage()
    {
        stage = SLIME_EVENT.EXIT;
    }

 


    IEnumerator Attacks(string attackName)
    {
        Debug.Log("test");
            yield return new WaitForSeconds(1);
    }
    void PursuitPlayer(bool pursuitPlayer)
    {
        if(pursuitPlayer)
        {
            anim.SetBool("isWalking", true);
        }
        else if(pursuitPlayer == false)
        {
            anim.SetBool("isWalking", false);
        }
    }

}
