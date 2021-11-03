using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData data){
        if(gameObject.name == "btnLeft"){
            Player.instance.SetMoveLeft(true);
        }else{
            Player.instance.SetMoveLeft(false);
        }
    }

    public void OnPointerUp(PointerEventData data){
         Player.instance.StopMoving();
    }
}
