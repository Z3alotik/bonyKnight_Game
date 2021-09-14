﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRangeX;
    public float attackRangeY;
    public int damage;

    private Animator anim;


    void Start(){

    anim = GetComponent<Animator>();
    }


    void Update(){

        if(timeBtwAttack <= 0){
        //Potom můžeš zaůtočit
            if(Input.GetKey(KeyCode.LeftAlt)){
                SoundManager.PlaySound("SwordSound");
                anim.SetTrigger("isAttacking");
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++){
                enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
            }
        }
        timeBtwAttack = startTimeBtwAttack;
        } else {
        timeBtwAttack -= Time.deltaTime;
        }
    }


    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }
}
