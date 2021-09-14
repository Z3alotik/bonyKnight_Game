using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    private HealthScript healthScript;


    void Start()
    {
      healthScript = GameObject.FindObjectOfType<HealthScript>();
    }


   public void HealPlayer(){
       healthScript.health += 2;
       Destroy(gameObject);
       SoundManager.PlaySound("PotionSound");
    }
}
