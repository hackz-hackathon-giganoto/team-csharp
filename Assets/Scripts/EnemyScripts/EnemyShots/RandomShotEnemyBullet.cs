using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の弾をランダムで生成するスクリプト
/// </summary>
public class RandomShotEnemyBullet : MonoBehaviour
{
    [SerializeField] private GameObject enemyBullet;

    [SerializeField] private float enemyBulletGenerationWatingTime;

    private int stopRandomShotEnemyBulletCount = 0;

    void Start()
    {
        
    }

    /// <summary>
    /// コルーチンを呼び出す関数
    /// </summary>
    public void CallRandomShot()
    {
        StartCoroutine("RandomShot");
    }

    /// <summary>
    /// 発射する弾を止める関数
    /// </summary>
    public void StopRandomEnemyBulletShot()
    {
        stopRandomShotEnemyBulletCount = 1;
    }

    /// <summary>
    /// 敵の弾をランダムで生成するコルーチン
    /// </summary>
    private IEnumerator RandomShot()
    {
        while (true)
        {
            if(stopRandomShotEnemyBulletCount == 1)
            {
                yield break;
            }
            GenerateRandomBullet();
            yield return new WaitForSeconds(enemyBulletGenerationWatingTime);
        }
    }

    /// <summary>
    /// 敵の弾をランダムで生成する関数
    /// </summary>
    void GenerateRandomBullet()
    {
        Instantiate(enemyBullet, this.transform.position, Quaternion.Euler(0, 0, Random.value * 360));
    }
}
