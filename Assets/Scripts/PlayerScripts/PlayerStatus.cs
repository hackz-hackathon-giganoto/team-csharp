using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーのステータスの管理クラス
/// </summary>
public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    private int firstPlayerHitPoint;

    [SerializeField]
    private int firstplayerBombCount;

    [NonSerialized]
    public int CurrentPlayerHitPoint;

    [NonSerialized]
    public int CurrentPlayerBombCount;

    [SerializeField]
    PlayerDestroy playerDestroy;

    private void Start()
    {
        CurrentPlayerHitPoint = firstPlayerHitPoint;
        CurrentPlayerBombCount = firstplayerBombCount;
    }

    private void FixedUpdate()
    {
        if (CurrentPlayerHitPoint <= 0)
        {
            playerDestroy.DestroyPlayer();
        }
    }

    /// <summary>
    /// ヒットポイントを増やすメソッド
    /// 引数を設定するとその引数分増やす
    /// </summary>
    public void IncreasePlayerHitPoint(int point = 1)
    {
        CurrentPlayerHitPoint += point;
    }

    /// <summary>
    /// ヒットポイントを減らすメソッド
    /// 引数を設定するとその引数分減らす
    /// </summary>
    public void DecreasePlayerHitPoint(int point = 1)
    {
        CurrentPlayerHitPoint -= point;
    }

    /// <summary>
    /// ボムの個数を増やすメソッド
    /// 引数を設定するとその引数分増やす
    /// </summary>
    public void IncreasePlayerBombCount(int count = 1)
    {
        CurrentPlayerBombCount += count;
    }

    /// <summary>
    /// ボムの個数を増やすメソッド
    /// 引数を設定するとその引数分減らす
    /// </summary>
    public void DecreasePlayerBombCount(int count = 1)
    {
        CurrentPlayerBombCount -= count;
    }
}
