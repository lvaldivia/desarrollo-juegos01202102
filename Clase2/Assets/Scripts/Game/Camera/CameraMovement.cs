using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float speed = 1.0f;
    private float accelaration = 0.2f;
    private float maxSpeed = 3.2f;
    [HideInInspector]
    public bool moveCamera;
    private float easySpeed = 3.2f;
    private float mediumSpeed = 3.7f;
    private float hardSpeed = 4.2f;
    public static CameraMovement instance;
    
    private void Awake() {
        instance = this;
    }
    void Start()
    {
        if(PlayerPrefs.HasKey("level")){
            int _level = PlayerPrefs.GetInt("level");
            if(_level == 1){
                maxSpeed = easySpeed;
            }
            if(_level == 2){
                maxSpeed = mediumSpeed;
            }
            if(_level == 3){
                maxSpeed = hardSpeed;
            }
        }
        moveCamera = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(moveCamera){
            MoveCamera();
        }
    }

    void MoveCamera(){
        Vector3 temp = transform.position;
        float oldY = temp.y;
        float newY = temp.y - (speed * Time.deltaTime);        
        temp.y = Mathf.Clamp(temp.y,oldY,newY);

        transform.position = temp;
        speed += accelaration*Time.deltaTime;
        if(speed>maxSpeed){
            speed = maxSpeed;
        }
    }
}
