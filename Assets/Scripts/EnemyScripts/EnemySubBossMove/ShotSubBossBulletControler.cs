using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ?T?u?{?X???g???e??ON/OFF?????????????X?N???v?g
/// </summary>
public class ShotSubBossBulletControler : MonoBehaviour
{
    [SerializeField] private EnemyBulletRotationShot enemyBulletRotationShotScript;
    [SerializeField] private RandomThrowUpShotEnemyBullet randomThrowUpShotEnemyBulletScript;
    [SerializeField] private ShotEnemyBullet shotEnemyBulletScript;
    [SerializeField] private RandomShotEnemyBullet randomShotEnemyBulletScript;
    [SerializeField] private EnemyStatus enemyStatusScript;
    [SerializeField] private SubBossBasicMove subBossBasicMoveScript;
    [SerializeField] private SubBossFirstMove subBossFirstMoveScript;

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
    [SerializeField] private float subBossBasicMoveTriggerHitPointPercent;
    [SerializeField] private float normalRotationShotFinishHitPointPercent;
    [SerializeField] private float stopFirstRotationShotFinishHitPointPercent;
    [SerializeField] private float randomThrowUpShotFinishHitPointPercent;
    [SerializeField] private float randomShotFinishHitPointPercent;
    [SerializeField] private float normalShotFinishHitPointPercent;
    [SerializeField] private float subBossBasicMoveFinishHitPointPercent;
    [SerializeField] private float subBossFirstMoveFinishHitPointPercent;
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
        enemyHitPointPercent = enemyHitPoint / enemyMaxHitPoint * fixPercent;
        NormalRotationShotJudge();
        StopFirstRotationShotJudge();
        RandomThrowUpShotJudge();
        RandomShotJudge();
        NormalShotJudge();
        SubBossBasicMoveJudge();
        SubBossFirstMoveJudge();
    }

    /// <summary>
    /// ?G???~???????????????e????????????????????????????
    /// </summary>
    void NormalRotationShotJudge()
    {
        if (normalRotationShot && normalRotationShotActiveCount == 0 && normalRotationShotTriggerHitPointPercent >= enemyHitPointPercent)
        {
            normalRotationShotActiveCount++;
            enemyBulletRotationShotScript.CallFirstShotPattern();
        }
        if (normalRotationShotActiveCount == 1 && normalRotationShotFinishHitPointPercent >= enemyHitPointPercent)
        {
            normalRotationShotActiveCount++;
            enemyBulletRotationShotScript.StopFirstShotPattern();
        }
    }

    /// <summary>
    /// ?G???~???????????????e????????????????????????????
    /// </summary>
    void StopFirstRotationShotJudge()
    {
        if (stopFirstRotationShot && stopFirstRotationShotActiveCount == 0 && stopFirstRotationShotTriggerHitPointPercent >= enemyHitPointPercent)
        {
            stopFirstRotationShotActiveCount++;
            enemyBulletRotationShotScript.CallSecondShotPattern();
        }
        if (stopFirstRotationShotActiveCount == 1 && stopFirstRotationShotFinishHitPointPercent >= enemyHitPointPercent)
        {
            stopFirstRotationShotActiveCount++;
            enemyBulletRotationShotScript.StopSecondShotPattern();
        }
    }

    /// <summary>
    /// ?G???e????????????????????????????????????????
    /// </summary>
    void RandomThrowUpShotJudge()
    {
        if (randomThrowUpShot && randomThrowUpShotActiveCount == 0 && randomThrowUpShotTriggerHitPointPercent >= enemyHitPointPercent)
        {
            randomThrowUpShotActiveCount++;
            randomThrowUpShotEnemyBulletScript.CallRandomThrowUpShot();
        }
        if (randomThrowUpShotActiveCount == 1 && randomThrowUpShotFinishHitPointPercent >= enemyHitPointPercent)
        {
            randomThrowUpShotActiveCount++;
            randomThrowUpShotEnemyBulletScript.StopRandomThrowUpEnemyBulletShot();
        }
    }

    /// <summary>
    /// ?G???e???????_??????????????????????????????
    /// </summary>
    void RandomShotJudge()
    {
        if (randomShot && randomShotActiveCount == 0 && randomShotTriggerHitPointPercent >= enemyHitPointPercent)
        {
            randomShotActiveCount++;
            randomShotEnemyBulletScript.CallRandomEnemyShot();
        }
        if (randomShotActiveCount == 1 && randomShotFinishHitPointPercent >= enemyHitPointPercent)
        {
            randomShotActiveCount++;
            randomShotEnemyBulletScript.StopRandomEnemyShot();
        }
    }

    /// <summary>
    /// ?G???e?????????u????????????????????????????
    /// </summary>
    void NormalShotJudge()
    {
        if (normalShot && normalShotActiveCount == 0 && normalShotTriggerHitPointPercent >= enemyHitPointPercent)
        {
            normalShotActiveCount++;
            shotEnemyBulletScript.CallShot();
        }
        if (normalShotActiveCount == 1 && normalShotFinishHitPointPercent >= enemyHitPointPercent)
        {
            normalShotActiveCount++;
            shotEnemyBulletScript.StopNormalEnemyBulletShot();
        }
    }

    /// <summary>
    /// ?G?????{????????????????????????????
    /// </summary>
    void SubBossBasicMoveJudge()
    {
        if(subBossBasicMoveTriggerHitPointPercent >= enemyHitPointPercent)
        {
            subBossBasicMoveScript.CallMoveSubBoss();
        }
        if(subBossBasicMoveFinishHitPointPercent >= enemyHitPointPercent)
        {
            subBossBasicMoveScript.StopSubBoss();
        }
    }

    /// <summary>
    /// ?G???????????????I????????????????????????
    /// </summary>
    void SubBossFirstMoveJudge()
    {
        if(subBossFirstMoveFinishHitPointPercent >= enemyHitPointPercent)
        {
            subBossFirstMoveScript.StopSubBossFirstMove();
        }
    }
}
