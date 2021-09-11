using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other) {
        var gObject = other.gameObject;
        if(gObject.tag == "Obstacles"){
           Destroy(gObject);
        }
        
    }
    /*
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("collision enter con "+other.gameObject.name);
    }*/
}
