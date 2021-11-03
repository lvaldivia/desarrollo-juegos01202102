using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    [SerializeField]
    private Button backBtn;
    [SerializeField]
    private Button btnResume;
    [SerializeField]
    private Button btnMenu;
    [SerializeField]
    private GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        backBtn.onClick.AddListener(ReturnGame);
        btnResume.onClick.AddListener(ResumenGame);
        btnMenu.onClick.AddListener(MenuGame);
        panel.SetActive(false);
    }

   void ReturnGame(){
       Time.timeScale = 0f;
       panel.SetActive(true);
   }

   void ResumenGame(){
       panel.SetActive(false);
       Time.timeScale = 1f;
   }

   void MenuGame(){
      
   }
}
