using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Button btnFruit;
    [SerializeField]
    private Button btnTransport;
    [SerializeField]
    private Button btnCandy;
    [SerializeField]
    private Button btnConfig;
    // Start is called before the first frame update
    void Start()
    {
        btnFruit.onClick.AddListener(GoFruit);
        btnTransport.onClick.AddListener(GoTransport);
        btnCandy.onClick.AddListener(GoCandy);
        btnConfig.onClick.AddListener(OpenConfigPanel);
    }

    void OpenConfigPanel(){
        SettingsPanel.instance.OpenPanel();
    }

    void GoCandy(){

    }

    void GoTransport(){
        
    }

    void GoFruit(){
        
    }
}
