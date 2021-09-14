using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

    

    void Start(){

        inventory = GameObject.FindObjectOfType<Inventory>();
    }


    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            for(int i = 0; i < inventory.slots.Length; i++){
                if(inventory.isFull[i] == false){
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    SoundManager.PlaySound("ItemPickupSound");
                    break;
                }
            }
        }
    }
}
