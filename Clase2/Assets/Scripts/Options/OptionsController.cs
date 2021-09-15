using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    // Start is called before the first frame update
    public Button btnSoundOn;
    public Button btnSoundOff;
    void Start()
    {
        btnSoundOn.onClick.AddListener(DeactiveSound);
        btnSoundOff.onClick.AddListener(ActiveSound);
        int sound = 1;
        if(PlayerPrefs.HasKey("sound")){
            sound = PlayerPrefs.GetInt("sound");
        }
        if(sound == 1){
            btnSoundOn.gameObject.SetActive(true);    
            btnSoundOff.gameObject.SetActive(false);
        }else{
            btnSoundOn.gameObject.SetActive(false);    
            btnSoundOff.gameObject.SetActive(true);
        }
    }

    void ActiveSound(){
        PlayerPrefs.SetInt("sound",1);
        btnSoundOn.gameObject.SetActive(true);
        btnSoundOff.gameObject.SetActive(false);
    }

    void DeactiveSound(){
        PlayerPrefs.SetInt("sound",0);
        btnSoundOn.gameObject.SetActive(false);
        btnSoundOff.gameObject.SetActive(true);
    }
}
