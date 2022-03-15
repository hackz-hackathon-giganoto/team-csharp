using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の弾が円状に出るスクリプト
/// </summary>
public class EnemyBulletRotationShot : MonoBehaviour
{
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private GameObject stopFirstEnemyBullet;

    [SerializeField] private float enemyBulletGenerationWaitingTime;
    [SerializeField] private float enemyBulletRotationCount;
    [SerializeField] private float enemyBulletStopFirstRotationCount;
    [SerializeField] private float enemyBulletRotationInterval;
    [SerializeField] private float enemyBulletGenerationWaitingTimeAdd;
    [SerializeField] private float enemyBulletGenerationOnceRotationInterval;
    [SerializeField] private float rotationIntervalAdd;
    private float keepIntervalAddCount;
    private float keepCount;
    public float totalTime;
    private float totalAddTime;
    private float totalWaitAddTime;

    private int stopFirstStopEnemyBulletShotCount = 0;
    private int stopNomalEnemyBulletShotCount = 0;

    void Start()
    {
        keepCount = enemyBulletGenerationWaitingTime;
        totalTime = 0;
        for(int i = 0;i < 360 / enemyBulletRotationInterval;i++)
        {
            totalWaitAddTime += keepCount;
            totalAddTime += enemyBulletGenerationWaitingTimeAdd;
        }
        totalTime = enemyBulletRotationCount * (enemyBulletGenerationOnceRotationInterval + ((360 / enemyBulletRotationInterval) * enemyBulletGenerationWaitingTime) + totalAddTime);
        keepIntervalAddCount = rotationIntervalAdd;
    }

    /// <summary>
    /// コルーチンを呼び出す関数
    /// </summary>
    public void CallEnemyBullet()
    {
        StartCoroutine("ShotNormalBullet");
    }
    public void CallStopFirstEnemyBullet()
    {
        StartCoroutine("ShotStopFirstBullet");
    }
    public void StopFirstStopEnemyBulletShot()
    {
        stopFirstStopEnemyBulletShotCount++;
    }
    public void StopNormalEnemyBulletShot()
    {
        stopNomalEnemyBulletShotCount++;
    }


    /// <summary>
    /// 敵の弾を出すコルーチン
    /// </summary>
    private IEnumerator ShotNormalBullet()
    {
        for(float i = 0 ; i < enemyBulletRotationCount; i++ , rotationIntervalAdd += keepIntervalAddCount)
        {
            for (float j = 0; j < 360; j += enemyBulletRotationInterval, enemyBulletGenerationWaitingTime += enemyBulletGenerationWaitingTimeAdd)
            {
                if(stopNomalEnemyBulletShotCount == 1)
                {
                    yield break;
                }
                Instantiate(enemyBullet, new Vector3(this.transform.position.x,this.transform.position.y,1), Quaternion.Euler(0, 0, j + rotationIntervalAdd));
                yield return new WaitForSeconds(enemyBulletGenerationWaitingTime);
            }
            yield return new WaitForSeconds(enemyBulletGenerationOnceRotationInterval);
        }
    }

    /// <summary>
    /// 敵の弾を出すコルーチン
    /// </summary>
    private IEnumerator ShotStopFirstBullet()
    {
        for (float i = 0; i < enemyBulletStopFirstRotationCount; i++)
        {
            for (float j = 0; j < 360; j += enemyBulletRotationInterval, enemyBulletGenerationWaitingTime += enemyBulletGenerationWaitingTimeAdd)
            {
                if(stopFirstStopEnemyBulletShotCount == 1)
                {
                    yield break;
                }
                Instantiate(stopFirstEnemyBullet, new Vector3(this.transform.position.x, this.transform.position.y, 1), Quaternion.Euler(0, 0, j));
                yield return new WaitForSeconds(enemyBulletGenerationWaitingTime);
            }
            yield return new WaitForSeconds(enemyBulletGenerationOnceRotationInterval);
        }
    }
}
