using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelScript : MonoBehaviour
{
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")) {
            int i = Application.loadedLevel;
            Application.LoadLevel(i + 1);
        }
    }
}
