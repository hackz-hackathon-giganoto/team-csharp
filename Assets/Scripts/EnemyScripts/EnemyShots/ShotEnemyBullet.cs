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
    [SerializeField] private float circleCount;

    void Start()
    {
        StartCoroutine("Shot");
    }

    /// <summary>
    /// 敵の弾を生成するコルーチン
    /// </summary>
    private IEnumerator Shot()
    {
        while (true)
        {
            GenerateBullet();
            yield return new WaitForSeconds(enemyBulletGenerationWatingTime);
        }
    }

    /// <summary>
    /// 敵の弾を生成する関数
    /// </summary>
    void GenerateBullet()
    {
        for(float i = 1; i <= circleCount; i++)
        {
            for(float j = 0; j < 360; j += 360/enemyBulletCount)
            {
                Instantiate(enemyBullet,this.transform.position, Quaternion.Euler(0, 0, j));
            }
        }
        
    }
}
