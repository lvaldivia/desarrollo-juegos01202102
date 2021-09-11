using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider2D collider2D;
    Rigidbody2D body2D;
    void Start()
    {
        collider2D = GetComponent<BoxCollider2D>();
        body2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        var velocity = body2D.velocity;
        velocity.x -=  Time.deltaTime *5f;
        body2D.velocity = velocity;
        
    }
}
