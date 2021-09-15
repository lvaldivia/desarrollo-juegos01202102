using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HudController : MonoBehaviour
{
    [SerializeField]
    private Button btnPause;
    [SerializeField]
    private Text txtLife;
    [SerializeField]
    private Text txtCoins;
    private int life = 0;
    private int coins = 0;
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private Button btnQuit;
    [SerializeField]
    private Button btnResume;

    [SerializeField]
    private Button btnReady;

    public static HudController instance;

    private void Awake() {
        if(instance == null) {
            instance = this;
        }   
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        txtCoins.text = coins+"";
        txtLife.text = life+"";
        btnPause.onClick.AddListener(PauseGame);
        panel.SetActive(false);
        btnResume.onClick.AddListener(ResumenGame);
        btnQuit.onClick.AddListener(QuitGame);
        Time.timeScale = 0f;
        btnReady.onClick.AddListener(ReadyGame);
    }

    void ReadyGame(){
        Time.timeScale = 1f;
        gameObject.SetActive(true);
        btnReady.gameObject.SetActive(false);
    }

    void ResumenGame(){
        panel.SetActive(false);
        Time.timeScale = 1f;
    }

    void QuitGame(){
        StateManager.changeScene("Menu");
    }

    void PauseGame(){
        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void updateCoins(){
        coins++;
        txtCoins.text = coins+"";
    }
}
