using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScoreController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text txtScore;
    public Text txtCoin;
    void Start()
    {
        int coins = 0;
        int score = 0;
        if(PlayerPrefs.HasKey("coins")){
            coins = PlayerPrefs.GetInt("coins");
        }
        if(PlayerPrefs.HasKey("score")){
            score = PlayerPrefs.GetInt("score");
        }
        txtScore.text = score+"";
        txtCoin.text = coins+"";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
