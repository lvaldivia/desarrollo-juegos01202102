using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PanelController : MonoBehaviour
{
    // Start is called before the first frame update
    public Button btnExit;
    public Button btnContinue;
    void Start()
    {
        gameObject.SetActive(false);
        btnExit.onClick.AddListener(GoMenu);
        btnContinue.onClick.AddListener(GoGame);
    }

    void GoMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    void GoGame(){
        Time.timeScale = 1f;
         gameObject.SetActive(false);
    }
}
