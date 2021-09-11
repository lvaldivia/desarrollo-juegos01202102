using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnBack : MonoBehaviour
{
    Button button;
    public string scene;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ReturnPrev);
    }

    void ReturnPrev(){
        StateManager.changeScene(scene);
    }
}
