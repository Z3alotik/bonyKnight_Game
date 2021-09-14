using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

     public float speed;
     public float jumpForce;
     private float moveInput;

     private bool facingRight = true;

     private bool isGrounded;
     public Transform groundCheck;
     public float checkRadius;
     public LayerMask whatIsGround;

     private int extraJumps;
     public int extraJumpValue;

     private Rigidbody2D rb;
     private Animator anim;
     private HealthScript healthScript;
     private GameMaster gm;

  

    void Start(){

        anim = GetComponent<Animator>();
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
        healthScript = GameObject.FindObjectOfType<HealthScript>();
        gm = GameObject.FindGameObjectWithTag("gameMaster").GetComponent<GameMaster>();
    }


    void FixedUpdate(){

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
                                                                                                                        //Pohyb hráče doleva a doprava
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
                                                                                                                        //Animace pohybu, nečinnosti
        if(moveInput == 0){
            anim.SetBool("isRunning", false);
        } else {
            anim.SetBool("isRunning", true);
        }
                                                                                                                        //Podmínka pro otáčení Spritu
        if(facingRight == false && moveInput > 0){
            Flip();
        } else if(facingRight == true && moveInput < 0){
            Flip();
        }
    }

    void Update(){
                                                                                                                        //Skok, grounded + extra skoky
        if(isGrounded == true){
            anim.SetBool("isJumping", false);
            extraJumps = extraJumpValue;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0){
            SoundManager.PlaySound("JumpSound");
            anim.SetBool("isJumping", true);
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        } else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true){
            SoundManager.PlaySound("JumpSound");
            rb.velocity = Vector2.up * jumpForce;
        }

        if(healthScript.health <= 0){
            Application.LoadLevel(Application.loadedLevel);
        }
    }
                                                                                                                        //Metoda pro otáčení Spritu
        void Flip(){
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }

    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Coin")){
            gm.money += 1;
            Destroy(col.gameObject);
            SoundManager.PlaySound("CoinSound");
        }
    }
}
