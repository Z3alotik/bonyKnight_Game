using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimOnTrigger : MonoBehaviour{

    public Animator anim;

   
    void Start(){
        anim = GetComponent<Animator>();
         
    }

   
    void Update(){
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Player")){
            anim.SetTrigger("playerPassThrough");
        }
    }
}
