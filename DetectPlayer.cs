using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    private bool detected = false;
    private Transform player;
    public Transform enemy;

    public GameObject bullet;
    public Transform shootPoint;
    public float shootSpeed = 10f;
    public float shootRate = 1.3f;
    private float time;
    public float speed = 1f;
    void Start(){
        time = shootRate;
    }
    void FixedUpdate(){
        if(detected){
         time -= Time.deltaTime;
         Debug.Log("Moving!");
         Debug.Log(transform.forward);
            enemy.position +=Time.deltaTime * transform.forward * speed;
            if(time < 0){
                ShootPlayer();
                time = shootRate;
            }
        }
    }
    void Update()
    {
        if(detected){
            enemy.LookAt(player);
        }
    }
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            detected = true;
            player = other.transform;
        }else{
            detected = false;
        }
    }
    private void ShootPlayer(){
        GameObject currentBullet = Instantiate(bullet,shootPoint.position,shootPoint.rotation);
        Rigidbody rig = currentBullet.GetComponent<Rigidbody>();
        if(rig != null){
            rig.AddForce(transform.forward * shootSpeed,ForceMode.VelocityChange);
        }
        Destroy(currentBullet,5f);
    }
}
