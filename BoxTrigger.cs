using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    public Transform player;
    public float triggerDistance = 5f;
    public GameObject trigger;
    public GameObject weapon;
    public void Update(){
        float distance = Vector3.Distance(transform.position,player.position);
        if(distance <= triggerDistance){
            Action();
        }else{
            CounterAction();
        }
    }
    void Action(){
        trigger.SetActive(true);
        if(Input.GetKeyDown(KeyCode.F)){
            Debug.Log("You Grabbed a knife!");
            trigger.SetActive(false);
            weapon.SetActive(true);
            Destroy(gameObject);
        }
    }
    void CounterAction(){
        trigger.SetActive(false);
    }
}