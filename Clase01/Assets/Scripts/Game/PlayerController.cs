using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    Rigidbody2D body2D;

    bool canJump = false;
    public float jumpForce = 12f;
    float moveForward;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Walk");
        body2D = GetComponent<Rigidbody2D>();
    }

    public void Jump(){
        if(canJump){
            if(transform.position.x < 0){
                moveForward  = 1f;
            }else{
                moveForward = 0f;
            }
            body2D.velocity = new Vector2(moveForward,jumpForce);
            canJump = false;
            animator.Play("Jump");
        }
    }

    void Update(){
        if(Mathf.Abs(body2D.velocity.y) == 0){
            animator.Play("Walk");
            canJump = true;
        }
    }


}
