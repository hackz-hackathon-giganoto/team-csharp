using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 円形に弾を打つクラス
/// </summary>
public class ShotRoundEnemyBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyBullet;

    [SerializeField]
    private float enemyBulletGenerationCount;
    [SerializeField]
    private float enemyBulletGenerationIntervalSeconds;

    private bool stopShotEnemyBullet;

    /// <summary>
    /// 外からRoundEnemyShotを呼び出す
    /// </summary>
    public void CallRoundEnemyShot()
    {
        StartCoroutine(RoundEnemyShot());
    }

    /// <summary>
    /// 外からRoundEnemyShotを呼び出す
    /// </summary>
    public void StopRoundEnemyShot()
    {
        stopShotEnemyBullet = true;
    }

    /// <summary>
    /// 円形に弾を発射する間隔のコルーチン
    /// </summary>
    private IEnumerator RoundEnemyShot()
    {
        while (true)
        {
            if(stopShotEnemyBullet)
            {
                yield break;
            }

            GenerateRoundBullet();
            yield return new WaitForSeconds(enemyBulletGenerationIntervalSeconds);
        }
    }

    /// <summary>
    /// 円形に弾を発射するメソッド
    /// </summary>
    private void GenerateRoundBullet()
    {
        for(float j = 0; j < 360; j += 360/enemyBulletGenerationCount)
        {
            Instantiate(
                enemyBullet,
                new Vector3(this.transform.position.x,this.transform.position.y,1),
                Quaternion.Euler(0, 0, j)
            );
        }  
    }
}
