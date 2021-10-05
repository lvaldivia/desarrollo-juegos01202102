using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollector : MonoBehaviour
{
    private GameObject[] pipeholders;
    private float distance = 3.2f;
    private float lastPipesX;
    private float pipeMin = -1.7f;
    private float pipeMax = 1.7f;
    // Start is called before the first frame update
    void Awake(){
        pipeholders = GameObject.FindGameObjectsWithTag("PipeHolder");
        for (int i = 0; i < pipeholders.Length; i++)
        {
            Vector3 temp = pipeholders[i].transform.position;
            temp.y = Random.Range(pipeMin,pipeMax);
            pipeholders[i].transform.position = temp;
        }
        lastPipesX = pipeholders[0].transform.position.x;

         for (int i = 1; i < pipeholders.Length; i++)
        {
            if(lastPipesX < pipeholders[i].transform.position.x){
                lastPipesX = pipeholders[i].transform.position.x;
            }
            
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "PipeHolder"){
            Vector3 temp = other.transform.position;
            temp.x = lastPipesX + distance;
            temp.y = Random.Range(pipeMin,pipeMax);
            other.transform.position = temp;
            lastPipesX = temp.x;
        }
    }
}
