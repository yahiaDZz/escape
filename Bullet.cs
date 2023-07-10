using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage = 30f;
    private void OnCollisionEnter(Collision col){
        PlayerController pc = col.gameObject.GetComponent<PlayerController>();
    if(pc!=null){
        pc.TakeDamage(bulletDamage);
    }
    }
}
