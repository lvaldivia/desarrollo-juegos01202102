using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private AudioClip coinClip, lifeClip;
    private Vector3 previousPosition;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Coin"){
            HudController.instance.updateCoins();
            other.gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(coinClip,other.transform.position);
        }
        if(other.tag == "Life"){
            HudController.instance.updateLife();
            other.gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(lifeClip,other.transform.position);
        }
        if(other.tag == "BadCloud"){
            HudController.instance.reduceLife();
            other.gameObject.SetActive(false);
        }
    }
}
