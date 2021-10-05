
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJumper : MonoBehaviour
{
    // Start is called before the first frame update
    public float forceY = 300f;
    [SerializeField]
    private Rigidbody2D body;
    [SerializeField]
    private Animator anim;
    void Start()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack(){
        yield return new WaitForSeconds(Random.Range(2,7));
        forceY = Random.Range(250,550);
        body.AddForce(new Vector2(0,forceY));
        anim.Play("Attack");
        yield return new WaitForSeconds(.7f);
        StartCoroutine(Attack());
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Floor"){
            anim.Play("Iddle");
        }
        if(other.gameObject.tag == "Player"){
            Destroy(other.gameObject);
        }
    }

}
