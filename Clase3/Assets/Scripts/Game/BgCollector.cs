using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgCollector : MonoBehaviour
{
    
    private GameObject[] backgrounds;
    private GameObject[] grounds;
    private float lastBGX;
    private float lastGroundX;

    void Awake(){
        backgrounds = GameObject.FindGameObjectsWithTag("Background");
        grounds = GameObject.FindGameObjectsWithTag("Floor");

        lastBGX = backgrounds[0].transform.position.x;
        lastGroundX = grounds[0].transform.position.x;

        for (int i = 1; i < backgrounds.Length; i++)
        {
            if(lastBGX < backgrounds[i].transform.position.x){
                lastBGX = backgrounds[i].transform.position.x;
            }
        }

        for (int i = 1; i < grounds.Length; i++)
        {
            if(lastGroundX < grounds[i].transform.position.x){
                lastGroundX = grounds[i].transform.position.x;
            }
            
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
