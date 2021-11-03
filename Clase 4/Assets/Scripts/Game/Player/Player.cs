using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public float moveForce = 20f, jumpForce = 700f, maxVelocity =4f;
    private bool grounded;
    [SerializeField]
    private Rigidbody2D body;
    [SerializeField]
    private Animator anim;
    private bool moveLeft, moveRight;
    public static Player instance;
    [SerializeField]
    private Button jumpButton;

    private void Awake() {
        instance = this;
        InitializeVariables();
    }

    void InitializeVariables(){
        grounded = false;
        jumpButton.onClick.AddListener(Jump);

    }

   private void FixedUpdate() {
       PlayerWalkKeyboard();
       PlayerWalkJoystick();
   }

   public void SetMoveLeft(bool moveLeft){
       this.moveLeft = moveLeft;
       this.moveRight = !moveLeft;
   }

   public void Jump(){
       if(grounded){
           grounded = false;
           body.AddForce(new Vector2(0,jumpForce));
       }
   }

   public void StopMoving(){
       this.moveLeft = false;
       this.moveRight = false;
   }

   void PlayerWalkJoystick(){
       float forceX = 0;
       float vel = Mathf.Abs(body.velocity.x);
       if(moveRight){
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
       }else if(moveLeft){
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
       }else {
           anim.Play("Iddle");
       }
        body.AddForce(new Vector2(forceX,0));
   }

   public void BouncePlayer(float force){
       if(grounded){
           grounded = false;
           body.AddForce(new Vector2(0,force));
       }
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
