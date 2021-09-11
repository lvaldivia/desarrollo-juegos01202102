using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    // Start is called before the first frame update
    //public float prueba;
    //public int otraprueba;
    //public GameObject gObject;
    public List<GameObject> objects;
    private float elapsed;
    private int index = 0;
    void Start()
    {
        elapsed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if(elapsed >= 5f){
            elapsed = 0f;   
            index = Random.Range(0,objects.Count - 1);
            var position = new Vector3(transform.position.x,transform.position.y,0);
            Instantiate(objects[index],position,Quaternion.identity);            
        }
    }
}
