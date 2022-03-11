using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボムの処理
/// </summary>
public class BombFire : MonoBehaviour
{
    private bool isBombStandby;

    [SerializeField]
    private float bombIntervalTime;

    [SerializeField]
    private PlayerStatus playerStatus;

    [SerializeField]
    GetterPitch getterPitch;

    [SerializeField]
    private float useBombVolume;

    void Start()
    {
        isBombStandby = false;
    }

    void FixedUpdate()
    {
        if (getterPitch.pitchHighest > useBombVolume && !isBombStandby && playerStatus.CurrentPlayerBombCount != 0)
        {
            UseBomb();
            Debug.Log("Bomb!!");
        }
    }


    /// <summary>
    /// ボムを使用した時のメソッド
    /// </summary>
    void UseBomb()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }

        foreach(GameObject enemy in enemys)
        {
            enemy.GetComponent<EnemyStatus>().DecreaseEnemyHitPoint(5f);
        }
        playerStatus.DecreasePlayerBombCount();
        StartCoroutine("BombStandbyTime");
    }

    /// <summary>
    /// ボムのインターバルタイム
    /// </summary>
    IEnumerator BombStandbyTime()
    {
        isBombStandby = true;
        yield return new WaitForSeconds(bombIntervalTime);
        isBombStandby = false;
    }
}