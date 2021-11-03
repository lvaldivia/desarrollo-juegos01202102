using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float minX, maxY;
    private Transform player;
    void Start()
    {
        player = Player.instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null){
            Vector3 temp = transform.position;
            temp.x = player.position.x;
            if(temp.x < minX){
                temp.x = minX;
            }
            if(temp.y > maxY){
                temp.y = maxY;
            }
            temp.y = player.position.y + 3.2f;
            transform.position = temp;
        }
    }
}
