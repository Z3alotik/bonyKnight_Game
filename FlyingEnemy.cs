using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public int enemyHealth;
    public float amounttomovey;
    public float speed;
    public int enemyDamage;
    public int EXP;
    private int facing;
    private float currentposx;
    private float currentposy;

    private Animator anim;
    private HealthScript healthScript;


    void Start(){
        currentposy = gameObject.transform.position.y;
        anim = GetComponent<Animator>();
        healthScript = GameObject.FindObjectOfType<HealthScript>();
    }


    void Update(){
        
        //Podmínka pro zničení objektu monstra
        if (enemyHealth <= 0){
            SoundManager.PlaySound("Monster1DeathSound");
            Destroy(gameObject);
        }

        if (facing == 1 && gameObject.transform.position.y < currentposy - amounttomovey)
        {
            facing = 0;
            
        }

        if (facing == 0 && gameObject.transform.position.y > currentposy)
        {
            facing = 1;
            
        }

        if (facing == 0)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else if (facing == 1)
        {
            transform.Translate(-Vector2.up * speed * Time.deltaTime);
        }
    }

    //Metoda pro poškození monstra
    public void TakeDamage(int damage){
        enemyHealth -= damage;
        SoundManager.PlaySound("Monster1Sound");
    }

    //Metoda pro poškození hráče
    void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Player")){
            healthScript.health -= enemyDamage;
            SoundManager.PlaySound("HurtSound");
        }
    }
}