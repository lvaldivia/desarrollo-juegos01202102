using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PuzzleButtonAnimators : MonoBehaviour
{
    private int puzzleGame1 = 6;
    private int puzzleGame2 = 12;
    private int puzzleGame3 = 18;
    private int puzzleGame4 = 24;
    private int puzzleGame5 = 30;

    private List<Button> level1Buttons = new List<Button>();
    private List<Animator> level1Anims = new List<Animator>();
    // Start is called before the first frame update
    [SerializeField]
    private Button puzzleButton;

    public static PuzzleButtonAnimators instance;
    void Awake(){
        instance = this;
        CreateButtons();
        GetAnimators();
    }

    void Start()
    {
        AssignButtonsAndAnims();
    }

    void AssignButtonsAndAnims(){
        LayoutPuzzle.instance.SetLevelButtons(level1Buttons);
        LayoutPuzzle.instance.LayoutButtons(PlayerPrefs.GetInt("next_level"));
    }

    void CreateButtons(){
        for (int i = 0; i < puzzleGame2; i++)
        {
            Button btn = Instantiate(puzzleButton);
            btn.gameObject.name = ""+i;
            btn.onClick.AddListener(FlipElement);
            level1Buttons.Add(btn);
        }
    }

    void FlipElement(){
        string name = EventSystem.current.currentSelectedGameObject.name;
        StartCoroutine(TurnUpElement(System.Convert.ToInt32(name)));
    }

    IEnumerator TurnUpElement(int index){
        level1Anims[index].Play("TurnUp");
        yield return new WaitForSeconds(1f);
        LayoutPuzzle.instance.Flip(index);
    }

    public  void ResetElement(int index, Sprite backSprite){
        StartCoroutine(TurnDownElement(index,backSprite));
    }

    public void FadeOut(int index){
        StartCoroutine(FadeOutElement(index));
        
    }

    IEnumerator FadeOutElement(int index){
        yield return new WaitForSeconds(1.5f);
        level1Anims[index].Play("FadeOut");
    }

    IEnumerator TurnDownElement(int index, Sprite backSprite){
        level1Anims[index].Play("TurnDown");
        yield return new WaitForSeconds(1f);
        level1Buttons[index].image.sprite = backSprite;
    }

    void GetAnimators(){
        for (int i = 0; i < level1Buttons.Count; i++)
        {
            level1Anims.Add(level1Buttons[i].gameObject.GetComponent<Animator>());
            level1Buttons[i].gameObject.SetActive(false);
        }
    }
}
