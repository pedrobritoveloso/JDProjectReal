using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour{
    public Transform player; /*This is slightly different to the approach you took for the GameEnding Trigger.
     This script will check for the player character’s Transform instead of its GameObject.
      It will make it easier to access JohnLemon’s position and determine whether there is a clear line of sight to him*/
    bool m_IsPlayerInRange; //To check if the player is within the trigger zone
    public GameEnding gameEnding; //This will store a reference to the GameEnding script
    void OnTriggerEnter(Collider other){ //This function will be called when the player enters the trigger zone
        if(other.transform == player){
            m_IsPlayerInRange = true;
        }
    }
    void OnTriggerExit(Collider other){ //This function will be called when the player exits the trigger zone
        if(other.transform == player){
            m_IsPlayerInRange = false;
        }
    }
    void Update(){
        if(m_IsPlayerInRange){
            Vector3 direction = player.position - transform.position + Vector3.up; //This will calculate the direction from the Observer to the player
            Ray ray = new Ray (transform.position, direction); //This will create a ray from the Observer to the player
            RaycastHit raycastHit; //This will store information about what the ray hits
            if(Physics.Raycast(ray, out raycastHit)){ //This will cast the ray and check if it hits anything
                if(raycastHit.collider.transform == player){ 
                    gameEnding.CaughtPlayer ();
                }
            }
        }
    }
}
