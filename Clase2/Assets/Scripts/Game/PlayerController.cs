using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 8f, maxVelocity = 4f;
    [SerializeField]
    private BoxCollider2D collider;
    private Rigidbody2D body;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        FixedWalkKeyboard();
    }

    void FixedWalkKeyboard(){
        float forceX = 0f;
        float vel = Mathf.Abs(body.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");
        if(h > 0){
            if(vel< maxVelocity){
                forceX = speed;
            }
            Vector3 temp = transform.localScale;
            temp.x = 1f;
            transform.localScale = temp;
            anim.Play("Walking");
        }else if(h < 0){
            if(vel< maxVelocity){
                forceX = -speed;
            }
            Vector3 temp = transform.localScale;
            temp.x = -1f;
            transform.localScale = temp;
            anim.Play("Walking");
        }else{
            anim.Play("Standing");
        }
        body.AddForce(new Vector2(forceX,0));
    }
}
