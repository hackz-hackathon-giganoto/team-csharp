using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class IconAnimation : MonoBehaviour
{
    [SerializeField] RectTransform rectTransform;
    /// <summary>
    /// アイコン消失アニメーションを実行後Destroyするメソッド
    /// </summary>
    public void VanishIcon(){
        rectTransform.DOScale(
        new Vector3(0f, 0f),
        2f
        ).SetEase(Ease.InOutElastic).OnComplete(()=> 
        Destroy(this.gameObject)
        );
    }
    /// <summary>
    /// アイコン出現アニメーションを実行するメソッド
    /// </summary>
    public void AppearIcon(){
        rectTransform.DOScale(
        new Vector3(0.7f, 0.7f),
        1.7f
        ).SetEase(Ease.OutElastic);
    }
}
