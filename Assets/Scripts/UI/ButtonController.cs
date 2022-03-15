using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using DG.Tweening;

public class ButtonController : BaseButtonController
{
    
    protected override void OnPointerClick(string objectName)
    {
        switch (objectName){
            case "StartButton":
                this.StartButtonClick();
                break;
        }
    }
    protected override void OnPointerEnter(string objectName){
        switch (objectName){
            case "StartButton":
                this.StartButtonEnter();
                break;
        }
    }
    protected override void OnPointerExit(string objectName){
            switch (objectName){
            case "StartButton":
                this.StartButtonExit();
                break;
        }
    }

    private void StartButtonClick(){
        Debug.Log("ワイも動いたでー");
    }
    private void StartButtonEnter(){
        Debug.Log("ポインタがのったよ！");
    }
    private void StartButtonExit(){
        Debug.Log("ポインタが離れたよ！");
    }
}
