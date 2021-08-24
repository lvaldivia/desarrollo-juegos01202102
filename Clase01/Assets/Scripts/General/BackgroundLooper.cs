using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.1f;
    private Vector2 offset = Vector2.zero;
    private Material material;
    void Start()
    {
        material = GetComponent<Renderer>().material;
        GetComponent<Renderer>().sortingLayerName = "Background";
        offset = material.GetTextureOffset("_MainTex");
    }

    void Update()
    {
        offset.x +=speed * Time.deltaTime;
        material.SetTextureOffset("_MainTex",offset);
    }
}
