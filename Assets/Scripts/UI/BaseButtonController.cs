using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;


public class BaseButtonController : MonoBehaviour {

    public BaseButtonController button;
    public void OnClick()
    {
        if (button == null)
        {
            throw new System.Exception("Button instance is null!!");
        }
        button.OnClick(this.gameObject.name);
    }
    public void OnPointerEnter() {
        if (button == null)
        {
            throw new System.Exception("Button instance is null!!");
        }
        button.OnPointerEnter(this.gameObject.name);
    }
    public void OnPointerExit() {
        if (button == null)
        {
            throw new System.Exception("Button instance is null!!");
        }
        button.OnPointerExit(this.gameObject.name);
    }

    protected virtual void OnClick(string objectName){
        Debug.Log("Base Button");
    }

    protected virtual void OnPointerEnter(string objectName){
        Debug.Log("Base Button");
    }
    protected virtual void OnPointerExit(string objectName){
        Debug.Log("Base Button");
    }
}