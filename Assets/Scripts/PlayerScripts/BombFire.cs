using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using MyUtils;

/// <summary>
/// ボムの処理クラス
/// </summary>
public class BombFire : MonoBehaviour
{
    private bool isBombStandby;

    [SerializeField]
    private float bombIntervalSeconds;

    [SerializeField]
    private PlayerStatus playerStatus;

    [SerializeField]
    GetterPitch getterPitch;

    [SerializeField]
    private float volumeUseBomb;

    void Start()
    {
        isBombStandby = false;
    }

    void FixedUpdate()
    {
        if (getterPitch.pitchHighest > volumeUseBomb && !isBombStandby && playerStatus.CurrentPlayerBombCount != 0)
        {
            UseBomb();
        }
    }


    /// <summary>
    /// ボムを使用した時のメソッド
    /// </summary>
    void UseBomb()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        Utils.DestroyGameObjectsWithTag("EnemyBullet");

        foreach(GameObject enemy in enemys)
        {
            enemy.GetComponent<EnemyStatus>().DecreaseEnemyHitPoint(5f);
        }
        playerStatus.DecreasePlayerBombCount();
        StartCoroutine(BombStandbyTime());
    }

    /// <summary>
    /// ボムのインターバルタイム
    /// </summary>
    IEnumerator BombStandbyTime()
    {
        isBombStandby = true;
        yield return new WaitForSeconds(bombIntervalSeconds);
        isBombStandby = false;
    }
}