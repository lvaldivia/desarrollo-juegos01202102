using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalker : MonoBehaviour
{
    [SerializeField]
    private Transform startPos, endPost;
    private bool collision;
    public float speed = 1f;
    [SerializeField]
    private Rigidbody2D body;

    private void FixedUpdate() {
        Move();
        ChangeDirection();
    }

    void Move(){
        body.velocity = new Vector2(transform.localScale.x,0) * speed;
    }

    void ChangeDirection(){
        collision = Physics2D.Linecast(startPos.position,endPost.position,
            1 << LayerMask.NameToLayer("Floor")
        );
        Debug.DrawLine(startPos.position,endPost.position,Color.green);
        if(!collision){
            Vector3 temp = transform.localScale;
            if(temp.x == 1f){
                temp.x = -1f;
            }else{
                temp.x = 1f;
            }
            transform.localScale = temp;
        }
    }


    
}
