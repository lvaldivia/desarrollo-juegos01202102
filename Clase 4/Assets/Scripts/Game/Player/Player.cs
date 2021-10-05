using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveForce = 20f, jumpForce = 700f, maxVelocity =4f;
    private bool grounded;
    [SerializeField]
    private Rigidbody2D body;
    [SerializeField]
    private Animator anim;
    private bool moveLeft, moveRight;

    private void Awake() {
        InitializeVariables();
    }

    void InitializeVariables(){
        grounded = false;
        //para usar alguna variable mas
    }

   private void FixedUpdate() {
       PlayerWalkKeyboard();
   }

   void PlayerWalkKeyboard(){
       float forceX = 0f;
       float forceY = 0f;
       float vel = Mathf.Abs(body.velocity.x);
       float h = Input.GetAxisRaw("Horizontal");
       if(h > 0){
           if(vel < maxVelocity){
               if(grounded){
                   forceX = moveForce;
               }else{
                   forceX = moveForce * 1.1f;
               }
           }
           Vector3 scale = transform.localScale;
           scale.x = 1f;
           transform.localScale = scale;
           anim.Play("Walking");
       }else if(h < 0){
            if(vel < maxVelocity){
              if(grounded){
                   forceX = -moveForce;
               }else{
                   forceX = -moveForce * 1.1f;
               }
           }
           Vector3 scale = transform.localScale;
           scale.x = -1f;
           transform.localScale = scale;
           anim.Play("Walking");
       }else if(h == 0){
           anim.Play("Iddle");
       }
       if(Input.GetKey(KeyCode.Space)){
           if(grounded){
               grounded = false;
               forceY = jumpForce;
           }
       }
       body.AddForce(new Vector2(forceX,forceY));
   }

   private void OnCollisionEnter2D(Collision2D other) {
       if(other.gameObject.tag == "Floor"){
           grounded = true;
       }
   }
}
