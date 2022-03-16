using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ResultButtonController : BaseButtonController
{
    [SerializeField] ResultScene result;
    [SerializeField] PlayfabDataGateWay playfabGateway;
    [SerializeField] Text playerName;
    public int Score{get;set;}
     
    protected override void OnPointerClick(string objectName)
    {
        switch (objectName){
            case "SubmitButton":
                this.SubmitButtonClick();
                break;
            case "ExitButton":
                this.ExitButtonClick();
                break;
        }
    }
    protected override void OnPointerEnter(string objectName){
        switch (objectName){
            case "ExitButton":
                this.ExitButtonEnter();
                break;
        }
    }
    protected override void OnPointerExit(string objectName){
            switch (objectName){
            case "ExitButton":
                this.ExitButtonExit();
                break;
        }
    }

    private void SubmitButtonClick(){
        playfabGateway.Initialize(playerName.text,Score);
    }
    private void ExitButtonClick(){
        result.GoTitle();
    }
    private void ExitButtonEnter(){
        Debug.Log("ポインタがのったよ！");
    }
    private void ExitButtonExit(){
        Debug.Log("ポインタが離れたよ！");
    }
}
