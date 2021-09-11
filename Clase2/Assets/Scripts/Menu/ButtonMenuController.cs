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
    void Start()

    {
        btnStart.onClick.AddListener(GoGame);
        btnHighScore.onClick.AddListener(GoHighScore);
        btnOptions.onClick.AddListener(GoOptions);
        btnQuit.onClick.AddListener(GoQuit);
    }

    void GoGame(){
        StateManager.changeScene("Game");
    }

    void GoHighScore(){
        StateManager.changeScene("HighScore");
    }

    void GoOptions(){
        StateManager.changeScene("Options");
    }

    void GoQuit(){}
}
