using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EscapeTrigger : MonoBehaviour
{
    public Transform player;
    public GameObject text;
    public float minDistance = 3f;
    
    void Update()
    {
    float distance = Vector3.Distance(transform.position,player.position);
    if(distance<=minDistance){
        Action();
    }    
    else{
        CounterAction();
    }
    }
    void Action(){
        text.SetActive(true);
        if(Input.GetKeyDown(KeyCode.E)){
            //Escape
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
    void CounterAction(){
        text.SetActive(false);
    }
}
