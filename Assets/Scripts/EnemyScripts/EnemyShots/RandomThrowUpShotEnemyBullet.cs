using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の弾を上方向に指定した個数発射するスクリプト
/// </summary>
public class RandomThrowUpShotEnemyBullet : MonoBehaviour
{
    [SerializeField] private GameObject enemyGravityBullet;

    [SerializeField] private float enemyBulletGenerationWaitTime;

    [SerializeField] private int enemyGravityBulletCount;

    private int stopRandomThrowUpEnemyBulletShotCount = 0;

    void Start()
    {
        
    }

    /// <summary>
    /// 発射する弾を止める関数
    /// </summary>
    public void StopRandomThrowUpEnemyBulletShot()
    {
        stopRandomThrowUpEnemyBulletShotCount = 1;
    }

    /// <summary>
    /// コルーチンを呼び出す関数
    /// </summary>
    public void CallRandomThrowUpShot()
    {
        StartCoroutine("RandomGravityBulletShot");
    }

    /// <summary>
    /// 敵の弾を上方向に指定した個数発射するための関数
    /// </summary>
    private IEnumerator RandomGravityBulletShot()
    {
        while (true)
        {   
            if(stopRandomThrowUpEnemyBulletShotCount == 1)
            {
                yield break;
            }
            GenerateRandomGravityBullet();
            yield return new WaitForSeconds(enemyBulletGenerationWaitTime);
        }
    }

    /// <summary>
    /// 敵の弾を上方向に指定した個数発射する関数
    /// </summary>
    void GenerateRandomGravityBullet()
    {
        float EulerZ;
        

        for (int i = 0; i < enemyGravityBulletCount; i++)
        { 
            while(true)
            {
                EulerZ = Random.value * 360;
                if(EulerZ <= 135 && EulerZ >= 45)
                {
                    break;
                }
            }
            Instantiate(enemyGravityBullet, this.transform.position, Quaternion.Euler(0, 0, EulerZ)); 
        }
    }
     
}

      
