using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の弾を呼び出すスクリプト
/// </summary>
public class ShotEnemyBulletController : MonoBehaviour
{
    [SerializeField] private EnemyBulletRotationShot enemyBulletRotationShotScript;
    [SerializeField] private RandomThrowUpShotEnemyBullet randomThrowUpShotEnemyBulletScript;
    [SerializeField] private ShotEnemyBullet shotEnemyBulletScript;
    [SerializeField] private RandomShotEnemyBullet randomShotEnemyBulletScript;
    [SerializeField] private EnemyStatus enemyStatusScript;

    [SerializeField] private bool normalRotationShot;
    [SerializeField] private bool stopFirstRotationShot;
    [SerializeField] private bool randomThrowUpShot;
    [SerializeField] private bool randomShot;
    [SerializeField] private bool normalShot;

    [SerializeField] private float normalRotationShotTriggerHitPointPercent;
    [SerializeField] private float stopFirstRotationShotTriggerHitPointPercent;
    [SerializeField] private float randomThrowUpShotTriggerHitPointPercent;
    [SerializeField] private float randomShotTriggerHitPointPercent;
    [SerializeField] private float normalShotTriggerHitPointPercent;
    [SerializeField] private float normalRotationShotFinishHitPointPercent;
    [SerializeField] private float stopFirstRotationShotFinishHitPointPercent;
    [SerializeField] private float randomThrowUpShotFinishHitPointPercent;
    [SerializeField] private float randomShotFinishHitPointPercent;
    [SerializeField] private float normalShotFinishHitPointPercent;
    private float enemyMaxHitPoint;
    private float enemyHitPoint;
    private float enemyHitPointPercent;
    private float fixPercent = 100;

    private int normalRotationShotActiveCount = 0;
    private int stopFirstRotationShotActiveCount = 0;
    private int randomThrowUpShotActiveCount = 0;
    private int randomShotActiveCount = 0;
    private int normalShotActiveCount = 0;

    void Start()
    {
        enemyMaxHitPoint = enemyStatusScript.enemyHitPoint;
    }

    void Update()
    {
        enemyHitPoint = enemyStatusScript.enemyHitPoint;
        enemyHitPointPercent = enemyMaxHitPoint / enemyHitPoint * fixPercent;
        NormalRotationShotJudge();
        StopFirstRotationShotJudge();
        RandomThrowUpShotJudge();
        RandomShotJudge();
        NormalShotJudge();
    }

    /// <summary>
    /// 敵の円状に発射される弾が発射されるかを判定する関数
    /// </summary>
    void NormalRotationShotJudge()
    {
        if(normalRotationShot && normalRotationShotActiveCount == 0 && normalRotationShotTriggerHitPointPercent <= enemyHitPointPercent)
        {
            normalRotationShotActiveCount++;
            enemyBulletRotationShotScript.CallEnemyBullet();
        }
        if(normalRotationShotActiveCount == 1 && normalRotationShotFinishHitPointPercent >= enemyHitPointPercent)
        {
            normalRotationShotActiveCount++;
            enemyBulletRotationShotScript.StopNormalEnemyBulletShot();
        }
    }

    /// <summary>
    /// 敵の円状に発射される弾が発射されるかを判定する関数
    /// </summary>
    void StopFirstRotationShotJudge()
    {
        if(stopFirstRotationShot && stopFirstRotationShotActiveCount == 0 && stopFirstRotationShotTriggerHitPointPercent <= enemyHitPointPercent)
        {
            stopFirstRotationShotActiveCount++;
            enemyBulletRotationShotScript.CallStopFirstEnemyBullet();
        }
        if(stopFirstRotationShotActiveCount == 1 && stopFirstRotationShotFinishHitPointPercent >= enemyHitPointPercent)
        {
            stopFirstRotationShotActiveCount++;
            enemyBulletRotationShotScript.StopFirstStopEnemyBulletShot();
        }
    }

    /// <summary>
    /// 敵の弾が上方向に打ち上げられるかを判定する関数
    /// </summary>
    void RandomThrowUpShotJudge()
    {
        if(randomThrowUpShot && randomThrowUpShotActiveCount == 0 && randomThrowUpShotTriggerHitPointPercent <= enemyHitPointPercent)
        {
            randomThrowUpShotActiveCount++;
            randomThrowUpShotEnemyBulletScript.CallRandomThrowUpShot();
        }
        if(randomThrowUpShotActiveCount == 1 && randomThrowUpShotFinishHitPointPercent >= enemyHitPointPercent)
        {
            randomThrowUpShotActiveCount++;
            randomThrowUpShotEnemyBulletScript.StopRandomThrowUpEnemyBulletShot();
        }
    }

    /// <summary>
    /// 敵の弾がランダムに発射されるかを判定する関数
    /// </summary>
    void RandomShotJudge()
    {
        if(randomShot && randomShotActiveCount == 0 && randomShotTriggerHitPointPercent <= enemyHitPointPercent)
        {
            randomShotActiveCount++;
            randomShotEnemyBulletScript.CallRandomShot();
        }
        if (randomShotActiveCount == 1 && randomShotFinishHitPointPercent >= enemyHitPointPercent)
        {
            randomShotActiveCount++;
            randomShotEnemyBulletScript.StopRandomEnemyBulletShot();
        }
    }

    /// <summary>
    /// 敵の弾が一定間隔で発射されるかを判定する関数
    /// </summary>
    void NormalShotJudge()
    {
        if(normalShot && normalShotActiveCount == 0 && normalShotTriggerHitPointPercent <= enemyHitPointPercent)
        {
            normalShotActiveCount++;
            shotEnemyBulletScript.CallShot();
        }
        if(normalShotActiveCount == 1 && normalShotFinishHitPointPercent >= enemyHitPointPercent)
        {
            normalShotActiveCount++;
            shotEnemyBulletScript.StopNormalEnemyBulletShot();
        }
    }
}
