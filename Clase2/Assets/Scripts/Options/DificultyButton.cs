using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DificultyButton : MonoBehaviour
{
    Button btn;
    public GameObject check;
    public int level;
    private GameObject[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        check.SetActive(false);
        btn = GetComponent<Button>();
        btn.onClick.AddListener(ChangeDificulty);
    }

    // Update is called once per frame
    void ChangeDificulty(){
        buttons =  GameObject.FindGameObjectsWithTag("Button");
        foreach (var button in buttons)
        {
            button.GetComponent<DificultyButton>().ResetCheck();
        }
        check.SetActive(true);
    }

    public void ResetCheck(){
        check.SetActive(false);
    }
}
