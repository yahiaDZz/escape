using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround,whatIsPlayer;
    public float health = 100f;
    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    //States
    public float sightRange,attackRange;
    public bool playerInSightRange,playerInAttackRange;
    public GameObject bullet;
    public Transform shootPoint;
    public float shootSpeed = 10f;
    public float shootRate = 1f;
    public bool fixY = false;
    private float time;
    private float initY;
    void Awake()
    {
        player = GameObject.Find("First Person Player").transform;
        agent = GetComponent<NavMeshAgent>();
        initY = transform.position.y;
        time = shootRate;
    }
    public bool IsPositionInNavMesh(Vector3 position)
    {
        NavMeshHit hit;
        return NavMesh.SamplePosition(position, out hit, 0.1f, NavMesh.AllAreas);
    }
     void Update()
    {
        if(fixY)
     transform.position = new Vector3(transform.position.x,initY,transform.position.z);
     playerInSightRange = Physics.CheckSphere(transform.position,sightRange,whatIsPlayer);
     playerInAttackRange = Physics.CheckSphere(transform.position,attackRange,whatIsPlayer);
     
     if(!playerInSightRange && !playerInAttackRange){
        Patroling();
     }   
     else if(playerInSightRange && !playerInAttackRange){
        ChasePlayer();
     }
     else if(playerInSightRange && playerInAttackRange){
        AttackPlayer();
     }
    }
    void Patroling(){
        Debug.Log("Patroling!");
        if(!walkPointSet)SearchWalkPoint();
        if(walkPointSet)agent.SetDestination(walkPoint);
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if(distanceToWalkPoint.magnitude < 1f){
            walkPointSet = false;
        }
    }
    private void SearchWalkPoint(){
        float randomZ = Random.Range(-walkPointRange,walkPointRange);
        float randomX = Random.Range(-walkPointRange,walkPointRange);
        walkPoint = new Vector3(transform.position.x+randomX,transform.position.y,transform.position.z+randomZ);
        if(Physics.Raycast(walkPoint,-transform.up,2f,whatIsGround)){
            walkPointSet=true;
        }
    }
    void ChasePlayer(){
        agent.SetDestination(player.position); 
    }void AttackPlayer(){
          agent.SetDestination(player.position);
          transform.LookAt(player); 
          if(!alreadyAttacked){
            time-=Time.deltaTime;
            if(time<0){
            Shoot();
            time = shootRate;
            }
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack),timeBetweenAttacks);
          } 
    }
    void ResetAttack(){
        alreadyAttacked=false;
    }
    void Shoot(){
        GameObject currentBullet = Instantiate(bullet,shootPoint.position,shootPoint.rotation);
        Rigidbody rig = currentBullet.GetComponent<Rigidbody>();
        if(rig != null){
            rig.AddForce(transform.forward * shootSpeed,ForceMode.VelocityChange);
        }
        Destroy(currentBullet,5f);
    }
    public void TakeDamage(float damage){
        Debug.Log("Enemy taking damage!");
        health-=damage;
        if(health<=0){
            Invoke(nameof(Die),0.5f);
        }
    }
    private void Die(){
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,sightRange);
    }
}
