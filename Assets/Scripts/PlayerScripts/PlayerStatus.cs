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

    [SerializeField]
    private int firstPlayerPower;

    [NonSerialized]
    public int CurrentPlayerHitPoint;

    [NonSerialized]
    public int CurrentPlayerBombCount;

    [NonSerialized]
    public int CurrentPlayerPower;

    [SerializeField]
    private float invincibleTime;

    [SerializeField]
    PlayerDestroy playerDestroy;

    [SerializeField]
    PlayerRespawn playerRespawn;

    [SerializeField]
    IconPanel iconPanelHP;

    [SerializeField]
    IconPanel iconPanelBomb;

    private bool isInvincibleTime;

    private void Start()
    {
        CurrentPlayerHitPoint = firstPlayerHitPoint;
        CurrentPlayerBombCount = firstPlayerBombCount;
        CurrentPlayerPower = firstPlayerPower;

        iconPanelHP.SetIcon(firstPlayerHitPoint);
        iconPanelBomb.SetIcon(firstPlayerBombCount);
        isInvincibleTime = false;
    }

    /// <summary>
    /// ヒットポイントを増やすメソッド
    /// 引数を設定するとその引数分増やす
    /// </summary>
    public void IncreasePlayerHitPoint(int point = 1)
    {
        CurrentPlayerHitPoint += point;
        iconPanelHP.IncreseIcon();
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

            iconPanelHP.DecreseIcon();

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
    /// ヒットポイントを増やすメソッド
    /// 引数を設定するとその引数分増やす
    /// </summary>
    public void IncreasePlayerPower(int point = 1)
    {
        CurrentPlayerPower += point;
    }

    /// <summary>
    /// ヒットポイントを増やすメソッド
    /// 引数を設定するとその引数分増やす
    /// </summary>
    public void DecreasePlayerPower(int point = 1)
    {
        CurrentPlayerPower -= point;
    }

    /// <summary>
    /// ボムの個数を増やすメソッド
    /// 引数を設定するとその引数分増やす
    /// </summary>
    public void IncreasePlayerBombCount(int count = 1)
    {
        CurrentPlayerBombCount += count;

        iconPanelBomb.IncreseIcon();
    }

    /// <summary>
    /// ボムの個数を増やすメソッド
    /// 引数を設定するとその引数分減らす
    /// </summary>
    public void DecreasePlayerBombCount(int count = 1)
    {
        CurrentPlayerBombCount -= count;

        iconPanelBomb.DecreseIcon();
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
