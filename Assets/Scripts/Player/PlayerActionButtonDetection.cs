using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class PlayerActionButtonDetection : MonoBehaviour
{
    public float detectionRange;
    public GameObject NPCIcon;
    
    public GameObject closestNPC;
    public static Action<GameObject> onNPCInRange;
    public static Action onExitRange;
    
    //public Dictionary<Collider, float> objInRange;


    void Start()
    {
        //objInRange = new Dictionary<Collider, float>();
        
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider interactable)
    {
//        Debug.Log(interactable.name);
        if(interactable.tag == "NPC")
        {
            NPCIcon.SetActive(true);
            closestNPC = interactable.gameObject;
            onNPCInRange(closestNPC);
            NPCIcon.transform.position = new Vector3(interactable.transform.position.x, interactable.bounds.size.y, interactable.transform.position.z);




        }

    }

     void OnTriggerExit(Collider interactable)
     {
         NPCIcon.SetActive(false);
         closestNPC = null;
         onExitRange();
         

     }
    void OnDrawGizmosSelected()
    {
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireSphere(transform.position, detectionRange);
    }

}



/*        foreach (Collider thing in objectsNearby)
        {
            
            
            Vector3 targetPosition = (transform.position - thing.transform.position).normalized;
            RaycastHit hit;
            Ray betweenPlayerAndObj = new Ray(transform.position, targetPosition );

                //Debug.DrawRay(thing.transform.position, transform.position, Color.magenta, 0.5f);
                
                if (Physics.Raycast(betweenPlayerAndObj, out hit))
                {
                    
                    if (thing.tag == "NPC")
                    {
                        Debug.Log(hit.distance + " : " + thing.name);
                        if(thingsInRange.ContainsKey(thing))
                        {
                            thingsInRange[thing] = hit.distance;
                        }
                        else if (thingsInRange.ContainsKey(thing) == false)
                        {
                        thingsInRange.Add(thing, hit.distance);
                        //Debug.Log(thing + " " + hit.distance);
                        closestNPC = thingsInRange.OrderByDescending(k => k.Value).FirstOrDefault().Key.gameObject;
                        }                      
                        
                    }

                }

                
        }*/



