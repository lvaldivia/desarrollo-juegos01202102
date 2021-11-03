using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    public static Door instance;
    private int collectables;
    [SerializeField]
    private Animator animation;
    [SerializeField]
    private BoxCollider2D collider;
    private void Awake() {
        if(instance == null){
            instance = this;
        }
    }

    public void increaseCollectable(){
        collectables++;
    }

    public void decreaseCollectable(){
        collectables--;
        if(collectables == 0){
            animation.Play("OpenDoor");
            collider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            Debug.Log("pasar de nivel");
        }
    }
}
