using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemy : MonoBehaviour{

    public int enemyHealth;
    public float speed;
    public int enemyDamage;
    private float dazedTime;
    public float startDazedTime;

    public Transform target;
    public float chaseRange;

    private Animator anim;
    private HealthScript healthScript;


    void Start(){

        anim = GetComponent<Animator>();
        healthScript = GameObject.FindObjectOfType<HealthScript>();
        
    }

   
    void Update(){

        if (dazedTime <= 0){
            speed = 2;
        }else{
            speed = 0;
            dazedTime -= Time.deltaTime;
        }

        float distanceToTarget = Vector2.Distance(transform.position, target.position);
        if (distanceToTarget < chaseRange){
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, target.position.y), speed * Time.deltaTime);
         
        }

    }

    public void TakeDamage(int damage){
        enemyHealth -= damage;
        SoundManager.PlaySound("Monster1Sound");
    }

   
    void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Player")){
            healthScript.health -= enemyDamage;
            SoundManager.PlaySound("HurtSound");
        }
    }
}
