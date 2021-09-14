using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : MonoBehaviour {

    private PlayerAttack playerAttack;



    void Start(){
        playerAttack = GameObject.FindObjectOfType<PlayerAttack>();
    }

    void Update(){

    }

    private void UpgradePlayerDamage(){
        playerAttack.damage += 10;
        Destroy(gameObject);
    }
}
