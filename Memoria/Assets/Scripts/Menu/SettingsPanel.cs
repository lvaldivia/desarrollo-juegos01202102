using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField]
    private Button btnBack;

    [SerializeField]
    private Slider sliderMusic;

    [SerializeField]
    private GameObject panel;

    [SerializeField]
    private Animator animator;

    public static SettingsPanel instance;
    // Start is called before the first frame update

    void Awake(){
        instance = this;
    }

    void Start()
    {
        btnBack.onClick.AddListener(ClosePanel);
    }

    public void OpenPanel(){
        animator.Play("SlideIn");
    }

    void ClosePanel(){
        animator.Play("SlideOut");
    }
}
