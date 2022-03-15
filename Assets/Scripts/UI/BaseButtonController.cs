using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UniRx;
using DG.Tweening;


public class BaseButtonController : MonoBehaviour {
    public BaseButtonController button;
    private delegate void OnCompleteDelegate();
    private OnCompleteDelegate onComplete;
    public void OnPointerClick()
    {
        onComplete = (()=>button.OnPointerClick(this.gameObject.name));
        PlayPushButtonAnim(this.gameObject.GetComponent<RectTransform>());
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

    protected virtual void OnPointerClick(string objectName){
        Debug.Log("Base Button");
    }

    protected virtual void OnPointerEnter(string objectName){
        Debug.Log("Base Button");
    }
    protected virtual void OnPointerExit(string objectName){
        Debug.Log("Base Button");
    }

    private void PlayPushButtonAnim(RectTransform transform){
        Sequence sequence = DOTween.Sequence().Append(
        transform.DOMoveY(-0.13f,0.25f))
            .SetEase(Ease.OutQuint).SetRelative()
            .Append(transform.DOMoveY(0.13f,0.25f)).SetEase(Ease.OutQuint).SetRelative()
            .OnComplete(()=> 
            Debug.Log("アニメーションしたよ！")
        );
        onComplete();
    }
}