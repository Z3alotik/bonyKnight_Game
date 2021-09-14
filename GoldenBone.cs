using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenBone : MonoBehaviour
{
    private HealthScript healthScript;


        void Start()
        {
          healthScript = GameObject.FindObjectOfType<HealthScript>();
        }


       public void UpgradePlayerHealth(){
           healthScript.numOfHearts += 1;
           Destroy(gameObject);
        }
}
