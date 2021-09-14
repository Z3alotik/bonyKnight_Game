using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBoss : MonoBehaviour
{
    public float speed;
    public int enemyDamage;
    private bool EnemyfacingRight;
    private float currentposx;
    private int facing;
    public float amounttomovex;

    private Animator anim;
    private HealthScript healthScript;

    void Start()
    {

        currentposx = gameObject.transform.position.x;
        facing = 1;
        anim = GetComponent<Animator>();
        healthScript = GameObject.FindObjectOfType<HealthScript>();

    }
    private void Update(){
    if(facing == 1 && gameObject.transform.position.x < currentposx - amounttomovex){
            facing = 0;
            Flip();
}

        if(facing == 0 && gameObject.transform.position.x > currentposx){
            facing = 1;
            Flip();
        }

        if(facing == 1){
            transform.Translate(-Vector2.right* speed * Time.deltaTime);
        } else if(facing == 0){
            transform.Translate(Vector2.right* speed * Time.deltaTime);
        }
    }

    void Flip()
    {
        EnemyfacingRight = !EnemyfacingRight;
        Vector3 EnemyScale = transform.localScale;
        EnemyScale.x *= -1;
        transform.localScale = EnemyScale;
    }



    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            healthScript.health -= enemyDamage;
            SoundManager.PlaySound("HurtSound");
        }
    }
}
