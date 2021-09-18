using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    // Start is called before the first frame update
    float minX,maxX;
    void Start()
    {
        SetMinAndMax();
    }

    private void Update() {
        if(transform.position.x <minX){
            Vector3 temp = transform.position;
            temp.x = minX;
            transform.position = temp;
        }
        if(transform.position.x > maxX){
            Vector3 temp = transform.position;
            temp.x = maxX;
            transform.position = temp;
        }
    }

    void SetMinAndMax(){
        Vector3 bounds = 
            Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0));
        minX = -bounds.x;
        maxX = bounds.x;
    }
}
