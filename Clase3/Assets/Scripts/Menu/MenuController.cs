using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public Button btnPlay;
    public Button btnLeaderBoard;
    public Button btnTwitter;
    void Start()
    {
        
        btnPlay.onClick.AddListener(GoPlay);
        btnLeaderBoard.onClick.AddListener(GoLeaderBoard);
    }

    void GoPlay(){

    }

    void GoLeaderBoard(){
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
