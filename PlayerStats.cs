using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public GameObject Panel_PlayerStats;

    private bool statsOpen = false;

   
    public Text damageText;
    public Text healthText;

    private PlayerAttack playerAttack;
    private HealthScript healthScript;


    void Start() {
        Panel_PlayerStats.SetActive(false);
        playerAttack = GameObject.FindObjectOfType<PlayerAttack>();
        healthScript = GameObject.FindObjectOfType<HealthScript>();
    }

    void Update() {

        if (Input.GetButtonDown("PlayerStats")) {
            statsOpen = !statsOpen;
            SoundManager.PlaySound("ScrollOpenSound");
        }

        if (statsOpen) {
            Panel_PlayerStats.SetActive(true);
            Time.timeScale = 1;
        }

        if (!statsOpen) {
            Panel_PlayerStats.SetActive(false);
            Time.timeScale = 1;
        }

        damageText.text = "Damage: " + " " + playerAttack.damage;
        healthText.text = "Health: " + " " + healthScript.health;
    }

    
}