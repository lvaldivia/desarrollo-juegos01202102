using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bird : MonoBehaviour
{
    // Start is called before the first frame update
    public static Bird instance;
    [SerializeField]
    private Rigidbody2D body;
    [SerializeField]
    private Animator animator;
    private float forwardSpeed = 3f;
    private float bounceSpede = 4f;
    private bool didFlap;
    [HideInInspector]
    public bool isAlive;
    private Button flapButton;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip flapClick, pointClip, diedClip;
    private void Awake() {
        if(instance == null){
            instance = this;
        }    
        didFlap = false;
        isAlive = true;
        flapButton = GameObject.Find("btnFlap").GetComponent<Button>();
        flapButton.onClick.AddListener(Flap);
        SetCamerasX();
    }

    public float GetPosition(){
        return transform.position.x;
    }

    void Flap(){
        didFlap = true;
    }

    void SetCamerasX(){
        CameraMovement.offsetX = 
            (Camera.main.transform.position.x - transform.position.x) -1f;
    }

    private void FixedUpdate() {
        if(isAlive){
            Vector3 temp = transform.position;
            temp.x += forwardSpeed * Time.deltaTime;
            transform.position = temp;

            if(didFlap){
                didFlap = false;
                body.velocity = new Vector2(0,bounceSpede);
            }
            if(body.velocity.y >=0){
                transform.rotation = Quaternion.Euler(0,0,0);
            }else{
                float angle = 0;
                angle = Mathf.Lerp(0,-90,-body.velocity.y / 7);
                transform.rotation = Quaternion.Euler(0,0,angle);
            }

        }  
    }
}
