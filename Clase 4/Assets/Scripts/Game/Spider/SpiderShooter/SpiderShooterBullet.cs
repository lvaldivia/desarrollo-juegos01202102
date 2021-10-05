using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShooterBullet : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D other) {
      if(other.gameObject.tag == "Player"){
          Destroy(other.gameObject);
          Destroy(gameObject);
      }
      if(other.gameObject.tag == "Floor"){
          Destroy(gameObject);
      }
  }
}
