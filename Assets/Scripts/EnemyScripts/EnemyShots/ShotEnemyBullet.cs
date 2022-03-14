using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の弾を生成するスクリプト
/// </summary>
public class ShotEnemyBullet : MonoBehaviour
{
    [SerializeField] private GameObject enemyBullet;

    [SerializeField] private float enemyBulletCount;
    [SerializeField] private float enemyBulletGenerationWatingTime;

    private int stopShotEnemyBulletCount = 0;

    void Start()
    {
        
    }

    /// <summary>
    /// コルーチンを呼び出す関数
    /// </summary>
    public void CallShot()
    {
        StartCoroutine("Shot");
    }

    /// <summary>
    /// 発射する弾を止める関数
    /// </summary>
    public void StopNormalEnemyBulletShot()
    {
        stopShotEnemyBulletCount = 1;
    }

    /// <summary>
    /// 敵の弾を生成するコルーチン
    /// </summary>
    private IEnumerator Shot()
    {
        while (true)
        {
            if(stopShotEnemyBulletCount == 1)
            {
                yield break;
            }
            GenerateBullet();
            yield return new WaitForSeconds(enemyBulletGenerationWatingTime);
        }
    }

    /// <summary>
    /// 敵の弾を生成する関数
    /// </summary>
    void GenerateBullet()
    {
        for(float j = 0; j < 360; j += 360/enemyBulletCount)
        {
            Instantiate(enemyBullet,this.transform.position, Quaternion.Euler(0, 0, j));
        }
        
    }
}
