using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonController : BaseButtonController
{
    
    protected override void OnClick(string objectName)
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
        SceneManager.LoadScene("Main");
    }
    private void StartButtonEnter(){
        Debug.Log("ポインタがのったよ！");
    }
    private void StartButtonExit(){
        Debug.Log("ポインタが離れたよ！");
    }
}
