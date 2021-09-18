using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable() {
        Invoke("DestroyColectable",6.0f);   
    }

    void DestroyColectable(){
        gameObject.SetActive(false);
    }

}
