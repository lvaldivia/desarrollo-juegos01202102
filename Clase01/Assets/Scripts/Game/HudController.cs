using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class HudController : MonoBehaviour
{
    // Start is called before the first frame update
    public Button btnPause;
    public Text txtScore;
    public GameObject panel;
    float elapsed = 0f;
    void Start()
    {
        btnPause.onClick.AddListener(PauseGame);
    }

    void PauseGame(){
        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        txtScore.text = elapsed.ToString();
    }
}
