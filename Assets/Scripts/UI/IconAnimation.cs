using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class IconAnimation : MonoBehaviour
{
    [SerializeField] RectTransform rectTransform;
    public void VanishIcon(){
        rectTransform.DOScale(
        new Vector3(0f, 0f),
        3f
        ).SetEase(Ease.OutBack).OnComplete(()=> 
        Destroy(this.gameObject)
        );
    }
}
