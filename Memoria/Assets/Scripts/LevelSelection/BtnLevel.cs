using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnLevel : MonoBehaviour
{
    [SerializeField]
    private Button btn;

    [SerializeField]
    private GameObject starHolder;

    [SerializeField]
    private GameObject lockHolder;

    public int level;
    // Start is called before the first frame update
    void Start()
    {
        int currentLevel = 0;
        if(PlayerPrefs.HasKey("level")){
            currentLevel = PlayerPrefs.GetInt("level");
        }
        lockHolder.SetActive(!(currentLevel >= level));
        starHolder.SetActive(currentLevel>= level);
        btn.onClick.AddListener(GoLevel);
    }

    void GoLevel(){
        PlayerPrefs.SetInt("next_level",level);
        //Pasar al nuevo mundo
    }
}
