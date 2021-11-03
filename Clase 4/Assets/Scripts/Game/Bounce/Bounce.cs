using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    public float force = 500f;

    IEnumerator AnimateBounce(){
        animator.Play("Up");
        yield return new WaitForSeconds(.5f);
        animator.Play("Down");
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            StartCoroutine(AnimateBounce());
            Player.instance.BouncePlayer(force);
        }
    }
}
