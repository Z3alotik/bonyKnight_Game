using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

    private Inventory inventory;
    public int i;


    void Start() {

        inventory = GameObject.FindObjectOfType<Inventory>();
    }

    void Update() {       
            if (transform.childCount <= 0){
                inventory.isFull[i] = false;         
        }
    }
    public void DropItem(){
        foreach(Transform child in transform){
            child.GetComponent<SpawnItem>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }
}
