using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] clouds;
    private float distaceBetweenClouds = 3f;
    private float minX, maxX;
    private float lastCloudPositionY;
    private int controllX;
    private GameObject player;
    //TODO implementar monedas

    private void Awake() {
        controllX = 0;
        SetMinAndMax();
        CreateClouds(); 
        player = GameObject.Find("Player");
    }

    void Start()
    {
       PositionThePlayer();
    }

    void PositionThePlayer(){
        GameObject[] darksClouds = GameObject.FindGameObjectsWithTag("BadCloud");
        GameObject[] cloudsInGame = GameObject.FindGameObjectsWithTag("Cloud");

        for (int i = 0; i < darksClouds.Length; i++)
        {
            if(darksClouds[i].transform.position.y == 0){
                Vector3 t = darksClouds[i].transform.position;
                darksClouds[i].transform.position = 
                    new Vector3(cloudsInGame[0].transform.position.x,
                    cloudsInGame[0].transform.position.y,
                    cloudsInGame[0].transform.position.z
                    );
                cloudsInGame[0].transform.position = t;
            }
        }
        Vector3 temp = cloudsInGame[0].transform.position;
        for (int i = 1; i < cloudsInGame.Length; i++)
        {
            if(temp.y < cloudsInGame[i].transform.position.y){
                temp = cloudsInGame[i].transform.position;
            }
        }
        player.transform.position = new Vector3(temp.x,temp.y + 0.8f,temp.z);
    }

    void SetMinAndMax(){
        Vector3 bounds = 
            Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0));
        minX = -bounds.x + 0.5f;
        maxX = bounds.x -0.5f;
    }

    void CreateClouds(){
        Shuffle(clouds);
        float positionY = 0;
        for (int i = 0; i < clouds.Length; i++)
        {
            Vector3 temp = clouds[i].transform.position;
            temp.y = positionY;
            if(controllX == 0){
                temp.x = Random.Range(0,maxX);
                controllX = 1;
            }
            if(controllX == 1){
                temp.x = Random.Range(0,minX);
                controllX = 2;
            }
            if(controllX == 2){
                temp.x = Random.Range(1.0f,maxX);
                controllX = 3;
            }
            if(controllX == 3){
                temp.x = Random.Range(-1.0f,minX);
                controllX = 0;
            }
            lastCloudPositionY = positionY;
            clouds[i].transform.position = temp;
            positionY -= distaceBetweenClouds;
        }
    }

    void Shuffle(GameObject[] array){
        for (int i = 0; i < array.Length; i++)
        {   
            GameObject temp = array[i];
            int random = Random.Range(i,array.Length);
            array[i] = array[random];
            array[random] = temp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
