using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnLevel : MonoBehaviour
{
    // Start is called before the first frame update
    private Button btn;
    [SerializeField]
    private int level; 
    void Start()
    {
        btn.onClick.AddListener(GoLevel);   
    }

    private void GoLevel(){
        //swicth o if para mandar a distintos niveles
        SceneManager.LoadScene("Game");

    }
}
