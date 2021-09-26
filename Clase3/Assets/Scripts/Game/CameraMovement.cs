using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    public static float offsetX;
    private Bird bird;
    void Start()
    {
        bird = Bird.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(bird != null){
            if(bird.isAlive){
                MoveCamera();
            }
        }
    }

    void MoveCamera(){
        Vector3 temp = transform.position;
        temp.x = bird.GetPosition() + offsetX;
        transform.position = temp;
    }
}
