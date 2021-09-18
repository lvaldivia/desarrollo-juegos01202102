using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMenuController : MonoBehaviour
{
    public Button btnStart;
    public Button btnHighScore;
    public Button btnOptions;
    public Button btnQuit;
    public AudioClip clickClip;
    void Start()

    {
        btnStart.onClick.AddListener(GoGame);
        btnHighScore.onClick.AddListener(GoHighScore);
        btnOptions.onClick.AddListener(GoOptions);
        btnQuit.onClick.AddListener(GoQuit);
    }

    void GoGame(){
        AudioSource.PlayClipAtPoint(clickClip,btnStart.gameObject.transform.position);
        StateManager.changeScene("Game");
    }

    void GoHighScore(){
        AudioSource.PlayClipAtPoint(clickClip,btnHighScore.gameObject.transform.position);
        StateManager.changeScene("HighScore");
    }

    void GoOptions(){
        AudioSource.PlayClipAtPoint(clickClip,btnOptions.gameObject.transform.position);
        StateManager.changeScene("Options");
    }

    void GoQuit(){}
}
