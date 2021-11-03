using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutPuzzle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform puzzleLevel1;
    [SerializeField]
    private Sprite[] puzzleButtonsBackSideImages;
    [SerializeField]
    private Sprite[] puzzleBackImcage;
    private int level;

    public static LayoutPuzzle instance;

    private List<Button> levelButtons;
    private int totalFlips = 0;
    private string flipSelected = "";
    private List<int> buttonsSelected;

    void Awake(){
        buttonsSelected = new List<int>();
        instance = this;
    }

    public void SetLevelButtons(List<Button> levelButtons){
        this.levelButtons = levelButtons;
        totalFlips = this.levelButtons.Count;
    }


    public void LayoutButtons(int level){
        this.level = level;
        LayoutPuzzleInGame();
    }

    public void Flip(int index){
        levelButtons[index].image.sprite = puzzleButtonsBackSideImages[index];
        buttonsSelected.Add(index);
        string flipName = puzzleButtonsBackSideImages[index].name;
        if(flipSelected == ""){
            flipSelected = flipName;
        }else{
            if(flipSelected == flipName){
                foreach (int btn in buttonsSelected)
                {
                    PuzzleButtonAnimators.instance.FadeOut(btn);
                }
                buttonsSelected.Clear();
                totalFlips = totalFlips -2;
                if(totalFlips == 0){
                    Debug.Log("ganaste");
                }
            }else{
                foreach (int btn in buttonsSelected)
                {
                    PuzzleButtonAnimators.instance.ResetElement(btn,puzzleBackImcage[level]);
                }
                buttonsSelected.Clear();
            }
            flipSelected = "";
        }
    }

    public Sprite GetBackImagePuzzle(int index){
        return puzzleButtonsBackSideImages[index];
    }

    void LayoutPuzzleInGame(){
        switch(level){
            case 0:
                foreach (Button btn in levelButtons)
                {   
                    if(!btn.gameObject.activeInHierarchy){
                        btn.gameObject.SetActive(true);
                        btn.transform.SetParent(puzzleLevel1,false);
                        btn.image.sprite = puzzleBackImcage[level];
                    }
                }
            break;
        }
    }

    
}
