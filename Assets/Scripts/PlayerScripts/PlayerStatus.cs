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
    private int firstPlayerBombCount;

    [NonSerialized]
    public int CurrentPlayerHitPoint;

    [NonSerialized]
    public int CurrentPlayerBombCount;

    [SerializeField]
    private float invincibleTime;

    [SerializeField]
    PlayerDestroy playerDestroy;

    [SerializeField]
    PlayerRespawn playerRespawn;

    private bool isInvincibleTime;

    private void Start()
    {
        CurrentPlayerHitPoint = firstPlayerHitPoint;
        CurrentPlayerBombCount = firstPlayerBombCount;
        isInvincibleTime = false;
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
        if (!isInvincibleTime)
        {
            CurrentPlayerHitPoint -= point;

            playerRespawn.RespawnPlayer();

            StartCoroutine("PlaeyrInvincibleTime");
        }

        if (CurrentPlayerHitPoint < 0)
        {
            playerDestroy.DestroyPlayer();
            Debug.Log("Destroy!!");
        }
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

    /// <summary>
    /// プレイヤーの無敵時間の実装をしました
    /// </summary>
    IEnumerator PlaeyrInvincibleTime()
    {
        isInvincibleTime = true;

        yield return new WaitForSeconds(invincibleTime);

        isInvincibleTime = false;
    }
}
