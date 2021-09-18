using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] backgrounds;
    private float lastY;
    // Start is called before the first frame update
    void Start()
    {
        GetBackgroundsAndSetLastY();
    }

    void GetBackgroundsAndSetLastY(){
        backgrounds = GameObject.FindGameObjectsWithTag("Background");
        lastY = backgrounds[0].transform.position.y;

        for (int i = 1; i < backgrounds.Length; i++)
        {
            if(lastY > backgrounds[i].transform.position.y){
                lastY = backgrounds[i].transform.position.y;
            }
        }

    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Background"){
            if(other.transform.position.y == lastY){
                Vector3 temp = other.transform.position;
                float height = ((BoxCollider2D)other).size.y;

                for (int i = 0; i < backgrounds.Length; i++)
                {
                    if(!backgrounds[i].activeInHierarchy){
                        temp.y -= height;
                        lastY = temp.y;
                        backgrounds[i].transform.position = temp;
                        backgrounds[i].SetActive(true);
                    }
                }
            }
        }
    }
}
