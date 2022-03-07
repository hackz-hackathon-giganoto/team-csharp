using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 音程が低い時の弾の大きさを管理するクラス
/// </summary>
public class LowPitchPlayerBulletBigger : MonoBehaviour
{
    Vector3 changeSize;

    private float amountIncrease;

    Transform bulletFirstTransform;

    float aliquotBiggerSize;

    [SerializeField]
    float finalPosition;

    [SerializeField]
    float finalSize;


    void Start()
    {
        SetAmountIncrease();
    }

    void FixedUpdate()
    {
        changeSize.x += amountIncrease;
        changeSize.y += amountIncrease;

        gameObject.transform.localScale = changeSize;
    }

    /// <summary>
    /// 一定の範囲の分割する範囲を求める数式
    /// TODO:ちょっとわかりづらいコメントアウトなのでもっとわかりやすくしたい
    /// </summary>
    void SetAmountIncrease()
    {
        bulletFirstTransform = gameObject.transform;
        changeSize = bulletFirstTransform.localScale;
        aliquotBiggerSize = (finalPosition - bulletFirstTransform.position.y) * 5f;
        finalSize -= bulletFirstTransform.localScale.x;
        amountIncrease = finalSize / aliquotBiggerSize;
    }
}
