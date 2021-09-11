using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnJump : MonoBehaviour
{
    // Start is called before the first frame update
    Button button;
    GameObject player;
    PlayerController playerController;
    void Start()
    {
        button  = GetComponent<Button>();
        button.onClick.AddListener(PlayerJump);
        player = GameObject.Find("Player");
        playerController  = player.GetComponent<PlayerController>();
    }

    void PlayerJump()
    {
        playerController.Jump();
    }
}
