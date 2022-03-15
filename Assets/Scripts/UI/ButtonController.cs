using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using DG.Tweening;

public class ButtonController : BaseButtonController
{
    
    protected override void OnPointerClick(string objectName,RectTransform transform)
    {
        switch (objectName){
            case "StartButton":
                this.StartButtonClick(transform);
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

    private void StartButtonClick(RectTransform transform){
        transform.DOMoveY(
            -0.13f,0.25f
            ).SetEase(Ease.OutQuint).SetRelative().OnComplete(()=> 
        transform.DOMoveY(
            0.13f,0.25f
            ).SetEase(Ease.OutQuint).SetRelative().OnComplete(()=> 
            Debug.Log("アニメーションしたよ！")
        //SceneManager.LoadScene("Main")
        ));
        
    }
    private void StartButtonEnter(){
        Debug.Log("ポインタがのったよ！");
    }
    private void StartButtonExit(){
        Debug.Log("ポインタが離れたよ！");
    }
}
