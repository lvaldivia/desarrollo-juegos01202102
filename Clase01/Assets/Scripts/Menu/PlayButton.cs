using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    // Start is called before the first frame update

    private Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(GoSceneGame);
    }

    void GoSceneGame(){
        Debug.Log("Vamos a la escena Game");
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
