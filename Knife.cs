using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    
    public float hitRange=1f;
    public float knifeDamage = 50f;
    public LayerMask enemyMask;
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Hit();
            }
    }
    private void Hit(){
        GetComponent<Animation>().Play();
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, hitRange);

        foreach (Collider collider in hitColliders)
        {
            if(collider.tag == "Enemy"){
                EnemyAI ea= collider.GetComponent<EnemyAI>();
                if(ea!=null){
                    ea.TakeDamage(knifeDamage);
                }
            }
        }
    }
}
