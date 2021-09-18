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
    [SerializeField]
    private GameObject[] collectables;
    //TODO implementar monedas

    private void Awake() {
        controllX = 0;
        SetMinAndMax();
        CreateClouds(); 
        player = GameObject.Find("Player");
        for(int i=0;i<collectables.Length;i++){
            collectables[i].SetActive(false);
        }
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

	void CreateClouds() {
		Shuffle (clouds);

		float positionY = 0;

		for(int i = 0; i < clouds.Length; i++) {

			Vector3 temp = clouds[i].transform.position;
			temp.y = positionY;
			if(controllX == 0) {
				temp.x = Random.Range(0, maxX);
				controllX = 1;
				
			} else if(controllX == 1) {
				
				temp.x = Random.Range(0, minX);
				controllX = 2;
				
			} else if(controllX == 2) {
				
				temp.x = Random.Range(1.0f, maxX);
				controllX = 3;
				
			} else if(controllX == 3) {
				
				temp.x = Random.Range(-1.0f, minX);
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

   private void OnTriggerEnter2D(Collider2D other) {
       if(other.tag == "BadCloud" || other.tag == "Cloud"){
           if(other.transform.position.y == lastCloudPositionY){
               Vector3 temp = other.transform.position;
               Shuffle(clouds);
               for(int i=0;i<clouds.Length;i++){
                   if(!clouds[i].activeInHierarchy){
                       if(controllX == 0) {
                            temp.x = Random.Range(0, maxX);
                            controllX = 1;
                            
                        } else if(controllX == 1) {
                            
                            temp.x = Random.Range(0, minX);
                            controllX = 2;
                            
                        } else if(controllX == 2) {
                            
                            temp.x = Random.Range(1.0f, maxX);
                            controllX = 3;
                            
                        } else if(controllX == 3) {
                            
                            temp.x = Random.Range(-1.0f, minX);
                            controllX = 0;
                        }
                        temp.y -= distaceBetweenClouds;
                        lastCloudPositionY = temp.y;
                        clouds[i].transform.position = temp;
                        clouds[i].SetActive(true);

                        int random = Random.Range(0,collectables.Length);
                        if(clouds[i].tag != "BadCloud"){
                            if(!collectables[random].activeInHierarchy){
                                if(collectables[random].tag == "Life"){
                                    if(HudController.instance.getLifes()< 2){
                                        collectables[random].SetActive(true);
                                        collectables[random].transform.position =
                                        new Vector3(clouds[i].transform.position.x,
                                        clouds[i].transform.position.y + 0.7f,
                                        clouds[i].transform.position.z
                                        );
                                    }
                                }else{
                                    collectables[random].SetActive(true);
                                     collectables[random].transform.position =
                                        new Vector3(clouds[i].transform.position.x,
                                        clouds[i].transform.position.y + 0.7f,
                                        clouds[i].transform.position.z
                                    );
                                }
                            }
                        }
                        //ACA SE IMPLEMENTA LOS COLLECTABLES
                   }
               }
           }
       }
   }
}
