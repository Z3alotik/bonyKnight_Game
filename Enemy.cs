using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth;
    public float amounttomovex;
    public float speed;
    public int enemyDamage;
    public int EXP;

    private float currentposx;
    private float currentposy;
    private int facing;
    private bool EnemyfacingRight;
    private bool EnemyfacingLeft;
    private float dazedTime;
    public float startDazedTime;

    private Animator anim;
    private HealthScript healthScript;


    void Start(){

        currentposx = gameObject.transform.position.x;
        facing = 1;
        anim = GetComponent<Animator>();
        healthScript = GameObject.FindObjectOfType<HealthScript>();

    }


    void Update(){
                                                                                                                        //Knockback ?
        if(dazedTime <= 0){
            speed = 2;
        } else {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }
                                                                                                                        //Podmínka pro zničení objektu monstra
        if(enemyHealth <= 0){
            SoundManager.PlaySound("Monster1DeathSound");
            Destroy(gameObject);

        }
                                                                                                                        //Podmínky pro otočení spritu
        if(facing == 1 && gameObject.transform.position.x < currentposx - amounttomovex){
            facing = 0;
            Flip();
        }

        if(facing == 0 && gameObject.transform.position.x > currentposx){
            facing = 1;
            Flip();
        }

        if(facing == 0){
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        } else if(facing == 1){
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }
    }

                                                                                                                        //Otočení spritu
    void Flip(){
        EnemyfacingRight = !EnemyfacingRight;
        Vector3 EnemyScale = transform.localScale;
        EnemyScale.x *= -1;
        transform.localScale = EnemyScale;
    }

                                                                                                                        //Metoda pro poškození monstra
    public void TakeDamage(int damage){
        enemyHealth -= damage;
        SoundManager.PlaySound("Monster1Sound");
    }

                                                                                                                        //Metoda pro poškození hráče
    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
        healthScript.health -= enemyDamage;
        SoundManager.PlaySound("HurtSound");
        }
    }
}